using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    internal class NaturalBinaryTree : BinaryTree
    {
        public NaturalBinaryTree(params int[] numbers) : base(numbers) { }
        public NaturalBinaryTree(IEnumerable<int> numbers) : base(numbers) { }
        public override bool Insert(int numb)
        {
            if (!IsNatural(numb))
                return false;

            return base.Insert(numb);
        }
        protected override void CreateTreeАFromIEnumerable(IEnumerable<int> numbers)
        {
            var naturalNumbers = numbers.Where(num => IsNatural(num));

            base.CreateTreeАFromIEnumerable(naturalNumbers);
        }
        private bool IsNatural(int num)
        {
            return num > 0;
        }
    }
}