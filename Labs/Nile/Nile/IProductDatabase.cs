/* ITSE 1430
 * Dalia Hussin
 * 11/28/218
 */
using System;
using System.Collections.Generic;

namespace Nile
{
    /// <summary>Provides a database of <see cref="Product"/> items.</summary>
    public interface IProductDatabase
    {
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        Product Add ( Product product );

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        Product Get ( int id );

        /// <summary>
        /// Get a specific product by name
        /// </summary>
        /// <param name="name">The product's name</param>
        /// <returns>The product, if it exists</returns>
        Product Get(string name);

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        IEnumerable<Product> GetAll ();

        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        void Remove ( int id );

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        Product Update ( Product product );
    }
}