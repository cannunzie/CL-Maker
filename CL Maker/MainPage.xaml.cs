using CL_Maker.Models;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Reflection;
namespace CL_Maker
{
	public partial class MainPage : ContentPage
	{
		List<string> frontEndList, backEndList;
		public MainPage()
		{
			InitializeComponent();

			frontEndList.Add("HTML");
			frontEndList.Add("JS");
			frontEndList.Add("HTML");
		}

		void OnClickCreateBtn(object sender, EventArgs e)
		{
			Models.Contact myContact = new("33 Auburn Crest Ln SE, Calgary, AB T3M 0Z1", "Caleb Annunziello", "calebannunziello@gmail.com");
			Company company = new(new Address(compAddressEntry.Text), compNameEntry.Text, compDeptEntry.Text, compManagerEntry.Text);
			//4995 Market St SE, Calgary, AB T3M 2P9

			//Creates a new document.
			using WordDocument document = new();
			//Adds a new section to the document.
			WSection section = document.AddSection() as WSection;
			//Sets Margin of the section.
			section.PageSetup.Margins.All = 72;
			//Sets the page size of the section.
			section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);

			//Creates Paragraph styles.
			WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
			style.CharacterFormat.FontName = "Calibri";
			style.CharacterFormat.FontSize = 11f;
			style.ParagraphFormat.BeforeSpacing = 0;
			style.ParagraphFormat.AfterSpacing = 8;
			style.ParagraphFormat.LineSpacing = 13.8f;

			style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
			style.ApplyBaseStyle("Normal");
			style.CharacterFormat.FontName = "Calibri Light";
			style.CharacterFormat.FontSize = 16f;
			style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
			style.ParagraphFormat.BeforeSpacing = 12;
			style.ParagraphFormat.AfterSpacing = 0;
			style.ParagraphFormat.Keep = true;
			style.ParagraphFormat.KeepFollow = true;
			style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;

			IWParagraph paragraph = section.AddParagraph();
			Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

			paragraph.ApplyStyle("Normal");

			paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
			paragraph.AppendText(myContact.GetName());
			paragraph.AppendBreak(BreakType.LineBreak);
			paragraph.AppendText(myContact.GetEmail());
			paragraph.AppendBreak(BreakType.LineBreak);
			paragraph.AppendText(myContact.GetAddress().GetStreet());
			paragraph.AppendBreak(BreakType.LineBreak);
			paragraph.AppendText(myContact.GetAddress().GetCity() + ", " + myContact.GetAddress().GetProvince());

			paragraph = section.AddParagraph();
			paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
			paragraph.AppendText(DateTime.Today.ToString("MMM dd, yyyy"));

			paragraph = section.AddParagraph();

			if (!string.IsNullOrEmpty(company.GetManager()))
			{
				paragraph.AppendText(company.GetManager());
				paragraph.AppendBreak(BreakType.LineBreak);
			}
			paragraph.AppendText(company.GetName());
			paragraph.AppendBreak(BreakType.LineBreak);
			if (!string.IsNullOrEmpty(company.GetDepartment()))
			{
				paragraph.AppendText(company.GetDepartment());
				paragraph.AppendBreak(BreakType.LineBreak);
			}
			paragraph.AppendText(company.GetAddress().GetStreet());
			paragraph.AppendBreak(BreakType.LineBreak);
			paragraph.AppendText(company.GetAddress().GetCity() + ", " + company.GetAddress().GetProvince());

			paragraph = section.AddParagraph();
			if(string.IsNullOrEmpty(company.GetManager()))
				paragraph.AppendText("Dear Hiring Manager,");
			else
				paragraph.AppendText("Dear " + company.GetManager() + ",");
			paragraph.AppendBreak(BreakType.LineBreak);

			string emailBody = "";
			emailBody += jobDescriptionEditor.Text;
			paragraph.AppendText(emailBody);

			using MemoryStream ms = new();
			//Saves the Word document to the memory stream.
			document.Save(ms, FormatType.Docx);
			ms.Position = 0;
			//Saves the memory stream as file.
			Services.SaveService saveService = new();
			saveService.SaveAndView("Sample.docx", "application/msword", ms);
		}
	}
}