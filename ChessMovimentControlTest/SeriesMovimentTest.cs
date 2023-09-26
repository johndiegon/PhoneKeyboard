using ChessMovimentControl.Service;

namespace ChessMovimentControlTest
{
    [TestClass]
    public class SeriesMovimentTest
    {

        public SeriesNumber _seriesNumber;

        public SeriesMovimentTest()
        {
            _seriesNumber = new SeriesNumber();
        }

        [DataRow('2')]
        [DataRow('3')]
        [DataRow('4')]
        [DataRow('5')]
        [DataRow('6')]
        [DataRow('7')]
        [DataRow('8')]
        [DataRow('9')]
        [TestMethod]
        public void AddFirstNumber_WithSucces(char value)
        {
            //arrange 
            _seriesNumber.Clear();

            //act
            _seriesNumber.AddNumber(value);

            //assert
            Assert.IsTrue(_seriesNumber.Get().Length == 1);
        }

        [DataRow('0')]
        [DataRow('1')]
        [DataRow('*')]
        [DataRow('#')]
        [DataRow('a')]
        [DataRow('A')]
        [TestMethod]
        public void AddFirstNumber_WithFail(char value)
        {
            //arrange 
            _seriesNumber.Clear();

            //act
            _seriesNumber.AddNumber(value);

            //assert
            Assert.IsTrue(_seriesNumber.Get().Length == 0);
        }


        [DataRow(new char[] { '8', '5', '2', '0', '2', '5', '8', '9', '5' })]
        [DataRow(new char[] { '6', '5', '4', '1', '5', '9', '6', '3', '6' })]
        [DataRow(new char[] { '1', '4', '7', '8', '5', '2', '0', '2', '6' })]
        [TestMethod]
        public void IsFinished_True(char[] values)
        {
            //arrange 
            _seriesNumber.Clear();

            //act
            foreach (char value in values)
                _seriesNumber.AddNumber(value);

            //assert
            var numbers = _seriesNumber.Get().Split('-');
            int number;

            Assert.IsTrue(_seriesNumber.IsFinished());
            Assert.IsTrue(_seriesNumber.Get().Length == 8);
            Assert.IsTrue(numbers.Length == 2);
            Assert.IsTrue(numbers[0].Length == 3);
            Assert.IsTrue(numbers[1].Length == 4);
            Assert.IsTrue(int.TryParse(numbers[0], out number));
            Assert.IsTrue(int.TryParse(numbers[1], out number));
        }


        [DataRow(new char[] { '4', '3', '4', '5', '6', '7', '8', '9', '2' })]
        [DataRow(new char[] { '4', '3', '4', '5', '6', '7', '8', '9', '2' })]
        [DataRow(new char[] { '4', '3', '4', '5', '6', '7', '8', '9', '2' })]
        [TestMethod]
        public void IsFinished_False(char[] values)
        {
            //arrange 
            _seriesNumber.Clear();

            //act
            foreach (char value in values)
                _seriesNumber.AddNumber(value);

            //assert

            Assert.IsFalse(_seriesNumber.IsFinished());
            Assert.IsFalse(_seriesNumber.Get().Length == 8);
        }

        [DataRow(new char[] { '8', '2', '5', '0', '2', '5', '8', '9', '5' })]
        [DataRow(new char[] { '4', '3', '4', '5', '6' })]
        [TestMethod]
        public void Clear_WithSuccess(char[] values)
        {
            //arrange 
            _seriesNumber.Clear();
            foreach (char value in values)
                _seriesNumber.AddNumber(value);

            //act
            _seriesNumber.Clear();

            //asset
            Assert.IsTrue(_seriesNumber.Get().Length == 0);
        }
    }
}