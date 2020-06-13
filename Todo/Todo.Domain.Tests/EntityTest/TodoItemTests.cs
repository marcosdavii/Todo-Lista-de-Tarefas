using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
     [TestClass]
        public class TodoItemTests
        {
            private readonly TodoItem _validTodo = new TodoItem("Aqui e o Titulo", "Marcos Davi", DateTime.Now);
            
           [TestMethod]
           public void Dado_um_novo_todo_n_comcluido()
           {
               Assert.AreEqual(_validTodo.Done, false);
           }
        }
}