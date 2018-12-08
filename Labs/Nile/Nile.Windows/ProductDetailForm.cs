/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class ProductDetailForm : Form
    {
        #region Construction

        public ProductDetailForm () //: base()
        {
            InitializeComponent();            
        }
        
        public ProductDetailForm ( string title ) : this()
        {
            Text = title;
        }

        public ProductDetailForm( string title, Product product ) : this(title)
        {
            Product = product;
        }
        #endregion
        
        /// <summary>Gets or sets the product being shown.</summary>
        public Product Product { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkDiscontinued.Checked = Product.IsDiscontinued;
            };
        }

        #region Event Handlers

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            var product = new Product()
            {
                Id = Product?.Id ?? 0,
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Price = GetPrice(_txtPrice),
                IsDiscontinued = _chkDiscontinued.Checked,
            };

            IEnumerable<ValidationResult> validationsResults = product.Validate(new ValidationContext(product));
            bool validationPassed = true;

            _errors.SetError(_txtName, "");
            _errors.SetError(_txtPrice, "");

            foreach (ValidationResult result in validationsResults)
            {
                IEnumerator<string> iterator = result.MemberNames.GetEnumerator();
                iterator.MoveNext();
                string errorLabel = iterator.Current;

                if (errorLabel.Equals("id"))
                    MessageBox.Show(result.ErrorMessage, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (errorLabel.Equals("name"))
                    _errors.SetError(_txtName, result.ErrorMessage);
                else if (errorLabel.Equals("price"))
                    _errors.SetError(_txtPrice, result.ErrorMessage);

                validationPassed = false;
            }

            if (!validationPassed)
                return;

            Product = product;
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Private Members

        private decimal GetPrice ( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            //Validate price            
            return -1;
        }                      
        #endregion
    }
}
