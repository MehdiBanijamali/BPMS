using System;
using System.Windows.Forms;
using BPMS.Core.Services;
using BPMS.Infrastructure.Data;

namespace BPMS.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly IPdfConverter _pdfConverter;
        private readonly DatabaseQuery _database;

        public MainForm()
        {
            InitializeComponent();

            _pdfConverter = new FormToPdfConverter();
            _database = new DatabaseQuery();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidator.ValidateRequiredFields(this))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            _database.InsertUser(txtName.Text, txtEmail.Text);

            MessageBox.Show("Saved successfully.");
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            var pdfBytes = _pdfConverter.ConvertFormToPdf(this);

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "PDF Files|*.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _pdfConverter.SavePdf(pdfBytes, dialog.FileName);
                }
            }
        }
    }
}
