/* ITSE 1430
 * Dalia Hussin
 * 11/28/218
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            // Check arguments
            if (product == null)
                throw new ArgumentNullException();

            //V alidate product
            if(product.Validate(new ValidationContext(product)).GetEnumerator().MoveNext())
                throw new ArgumentException();

            if (product.Id < 0 || product.Price < 0)
                throw new ArgumentOutOfRangeException();

            if (GetCore(product.Name) != null)
                throw new ArgumentException("Name is already taken.");

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            return GetCore(id);
        }

        public Product Get(string name)
        {
            return GetCore(name);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            // Check arguments
            if (product == null)
                throw new ArgumentNullException();

            // Validate product
            if (product.Validate(new ValidationContext(product)).GetEnumerator().MoveNext())
                throw new ArgumentException();
                        
            // Get existing product
            var existing = GetCore(product.Id);

            if (existing == null)
                throw new ArgumentException();

            Product someProduct = GetCore(product.Name);

            if (someProduct != null && existing.Id != someProduct.Id)
                throw new ArgumentException("Name is already taken.");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product GetCore(string name);
        
        #endregion
    }
}
