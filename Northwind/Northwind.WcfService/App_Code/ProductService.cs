using Northwind.Business.Abstract;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService : IProductService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }
}