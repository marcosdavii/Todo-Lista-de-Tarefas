using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]

    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "usuarioC", DateTime.Now));
        }


        [TestMethod]
        public void GetAll_consulta_user()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioB"));
            Assert.AreEqual(1, result.Count());
        }
    }
}