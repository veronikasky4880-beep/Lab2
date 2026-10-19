using System;
using System.Collections;
using System.Collections.Generic;
using Lab2.Collections;
using Lab2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА 3.2 (Варіант 10) ===\n");

            // Викликаємо методи для кожного завдання окремо
            DemonstrateTask2_Collections();

            DemonstrateTask3And4_BinaryTree();

            DemonstrateVariantMethods_Encryption();

            Console.WriteLine("\nРобота завершена. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        // ЗАВДАННЯ 2: Демонстрація масивів та колекцій
        private static void DemonstrateTask2_Collections()
        {
            Console.WriteLine("--- ЗАВДАННЯ 2. Дослідження колекцій ---");

            MyString s1 = new MyString("Apple", 2, true);
            MyString s2 = new MyString("Banana", 1, true);
            MyString s3 = new MyString("Cat", 3, false);
            MyString s4 = new MyString("Dog", 2, true);
            MyString s5 = new MyString("Elephant", 1, false);

            // 1. Масив
            Console.WriteLine("\n1. Масив (Array):");
            MyString[] array = new MyString[] { s1, s2 };
            array[0].Print(); // Прохід не робимо, просто показуємо доступ

            // 2. Звичайна колекція (ArrayList)
            Console.WriteLine("\n2. Неузагальнена колекція (ArrayList):");
            ArrayList arrayList = new ArrayList { s3, s4 };
            foreach (MyString item in arrayList)
            {
                item.Print();
            }

            // 3. Узагальнена колекція (List<T>)
            Console.WriteLine("\n3. Узагальнена колекція (List<T>):");
            List<MyString> genericList = new List<MyString> { s1, s2, s3 };

            // Основні операції
            genericList.Add(s4);                               // Додавання
            genericList.Add(s5);
            genericList.Remove(s2);                            // Видалення
            genericList[0] = new MyString("Update", 1, true);  // Оновлення

            foreach (var item in genericList) // Прохід
            {
                item.Print();
            }
            Console.WriteLine("----------------------------------------\n");
        }

        // ЗАВДАННЯ 3 і 4: Демонстрація бінарного дерева та ітератора (Preorder)
        private static void DemonstrateTask3And4_BinaryTree()
        {
            Console.WriteLine("--- ЗАВДАННЯ 3-4. Бінарне дерево (Preorder) ---");

            BinaryTree<MyString> tree = new BinaryTree<MyString>();

            // Додаємо об'єкти. Дерево само їх сортує завдяки CompareTo (за довжиною)
            tree.Add(new MyString("Banana", 1, true));   // 6 символів (Корінь)
            tree.Add(new MyString("Apple", 2, true));    // 5 символів (Піде вліво)
            tree.Add(new MyString("Cat", 3, false));     // 3 символи (Піде вліво від Apple)
            tree.Add(new MyString("Elephant", 1, false));// 8 символів (Піде вправо від Banana)
            tree.Add(new MyString("Dog", 2, true));      // 3 символи 
            tree.Add(new MyString("Fox", 5, true));      // 3 символи

            Console.WriteLine("Обхід дерева (Корінь -> Ліво -> Право):");

            // Працює наш власний ітератор (IEnumerator)
            foreach (MyString item in tree)
            {
                item.Print();
            }
            Console.WriteLine("----------------------------------------\n");
        }

        // Демонстрація специфічних методів варіанту (Шифрування)
        private static void DemonstrateVariantMethods_Encryption()
        {
            Console.WriteLine("--- Додатково: Демонстрація методів шифрування ---");

            MyString s = new MyString("SecretMessage", 3, true);

            Console.Write("Початковий стан: ");
            s.Print();

            s.Encrypt();
            Console.Write("Зашифровано (+3): ");
            s.Print();

            s.Decrypt();
            Console.Write("Розшифровано (-3): ");
            s.Print();
        }
    }
}
