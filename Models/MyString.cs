using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    // ЗАВДАННЯ 1. Опис класу
    public class MyString : IComparable<MyString>
    {
        public string Value { get; set; }
        public int Shift { get; set; }
        public bool Forward { get; set; }
        public int Length => Value != null ? Value.Length : 0;

        public MyString(string value, int shift, bool forward)
        {
            Value = value;
            Shift = shift;
            Forward = forward;
        }

        public void Encrypt()
        {
            char[] chars = Value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] = (char)(chars[i] + (Forward ? Shift : -Shift));
            Value = new string(chars);
        }

        public void Decrypt()
        {
            char[] chars = Value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] = (char)(chars[i] - (Forward ? Shift : -Shift));
            Value = new string(chars);
        }

        public void Print() => Console.WriteLine($"Рядок: '{Value}', Довжина: {Length}");

        public int CompareTo(MyString other)
        {
            if (other == null) return 1;
            return this.Length.CompareTo(other.Length);
        }
    }
}
