using System;
using System.Collections.Generic;
using System.Data.Entity;
using InfyInsight.store.DBStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace InfyInsight.test
{
    [TestClass]
    public class DBStoreTest
    {
        private DBStoreEntities _dbEntities;
        private DbSet<Product> _dbProducts;

        public DBStoreTest()
        {
            _dbEntities = Rhino.Mocks.MockRepository.GenerateMock<DBStoreEntities>();
            _dbProducts = Rhino.Mocks.MockRepository.GenerateMock<DbSet<Product>>();
        }

        [TestMethod]
        public void AddProduct_Test()
        {
            //Arrange
            _dbEntities.Stub(q => q.Products).Return(_dbProducts);
            _dbEntities.Stub(q => q.SaveChanges()).Return(1);
            var dbStore = new DBStoreRepository(_dbEntities);

            //Act
            var id = dbStore.AddProduct(new models.Product()
            {
                LongDescription = "Test Long Desc",
                Price = 20.50M,
                ProductType = models.ProductType.Book
            });

            //Assert
            Assert.IsTrue(id != Guid.Empty);
        }
    }
}
