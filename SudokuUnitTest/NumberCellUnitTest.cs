using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Models;

namespace SudokuUnitTest
{
    [TestClass]
    public class NumberCellUnitTest
    {
        [TestMethod]
        public void InitializeTest()
        {
            var cell = new NumberCell();

            Assert.AreEqual(false, cell.IsWormHole,"IsWormHole");

            Assert.AreEqual(null, cell.InputValue,"InputValue");
            Assert.AreEqual(1, cell.AnswerValue,"AnswerValue");
            Assert.AreEqual(1, cell.Value,"Value");
        }

        [TestMethod]
        public void IsWormHoleTest()
        {
            var cell = new NumberCell();

            cell.IsWormHole = false;
            Assert.AreEqual(false, cell.IsWormHole, "IsWormHole");

            Assert.AreEqual(null, cell.InputValue, "InputValue");
            Assert.AreEqual(1, cell.AnswerValue, "AnswerValue");
            Assert.AreEqual(1, cell.Value, "Value");

            cell.IsWormHole = true;
            Assert.AreEqual(true, cell.IsWormHole, "IsWormHole");

            Assert.AreEqual(null, cell.InputValue, "InputValue");
            Assert.AreEqual(1, cell.AnswerValue, "AnswerValue");
            Assert.AreEqual(null, cell.Value, "Value");
        }

        [TestMethod]
        public void AnswerValueTest()
        {
            var cell = new NumberCell();

            Assert.AreEqual(cell.AnswerValue, 1, "AnswerValue");

            try
            {
                cell.AnswerValue = 0;
            }
            catch (Exception exc)
            {
                Assert.IsInstanceOfType(exc, typeof(InvalidOperationException));
                Assert.AreEqual(cell.AnswerValue, 1, "AnswerValue");
            }

            cell.AnswerValue = 1;
            Assert.AreEqual(cell.AnswerValue, 1, "AnswerValue:" + cell.AnswerValue);

            cell.AnswerValue = 9;
            Assert.AreEqual(cell.AnswerValue, 9, "AnswerValue:" + cell.AnswerValue);

            try
            {
                cell.AnswerValue = 10;
            }
            catch (Exception exc)
            {
                Assert.IsInstanceOfType(exc, typeof(InvalidOperationException));
                Assert.AreEqual(cell.AnswerValue, 9, "AnswerValue");
            }
        }

        [TestMethod]
        public void InputValueTest()
        {
            var cell = new NumberCell();

            Assert.AreEqual(cell.InputValue, null, "InputValue");

            try
            {
                cell.InputValue = -1;
            }
            catch (Exception exc)
            {
                Assert.IsInstanceOfType(exc, typeof(InvalidOperationException));
                Assert.AreEqual(cell.InputValue, null, "InputValue");
            }

            cell.InputValue = 0;
            Assert.AreEqual(cell.InputValue, null, "InputValue:");

            cell.InputValue = null;
            Assert.AreEqual(cell.InputValue, null, "InputValue:");

            cell.InputValue = 1;
            Assert.AreEqual(cell.InputValue, 1, "InputValue:");

            cell.InputValue = 9;
            Assert.AreEqual(cell.InputValue, 9, "InputValue:");

            try
            {
                cell.InputValue = 10;
            }
            catch (Exception exc)
            {
                Assert.IsInstanceOfType(exc, typeof(InvalidOperationException));
                Assert.AreEqual(cell.InputValue, 9, "InputValue");
            }
        }
    }
}
