#if DEBUG
using System;
using TodoAppWpf.Model;

namespace TodoAppWpf.Helper
{
    /// <summary>
    /// Помогает заполнять представления данными, для работы в визуальном дизайнере
    /// </summary>
    class VisualDesignerDataGenerator
    {
        /// <summary>
        /// Текст заполнитель (<seealso cref="https://ru.wikipedia.org/wiki/Lorem_ipsum"/>)
        /// </summary>
        public const string LoremIpsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
            "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
            "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static readonly Random Generator = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Генерирует категорию
        /// </summary>
        /// <returns>Объект категории с заполненным именем</returns>
        public static Category GenerateCategory()
        {
            return new Category()
            {
                Name = LoremIpsum.Substring(Generator.Next(0, LoremIpsum.Length - 5), 5)
            };
        }

        /// <summary>
        /// Генерирует задачу
        /// </summary>
        /// <returns>Объект задачи с заполненным заголовком и содержимым</returns>
        public static Todo GenerateTodo()
        {
            return new Todo()
            {
                Header = LoremIpsum.Substring(0, 15),
                Content = LoremIpsum.Substring(0, Generator.Next(LoremIpsum.Length))
            };
        }

        /// <summary>
        /// Генерирует задачу
        /// </summary>
        /// <param name="category">Объект категории, который будет присвоен возвращённой задаче</param>
        /// <returns>Полностью заполненный объект задачи</returns>
        public static Todo GenerateTodo(Category category)
        {
            return new Todo()
            {
                Header = LoremIpsum.Substring(0, 15),
                Category = category,
                Content = LoremIpsum.Substring(0, Generator.Next(LoremIpsum.Length))
            };
        }
    }
}
#endif