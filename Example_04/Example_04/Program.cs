using System;
using Example_04.Adapters;
using Example_04.Adapters.ClassAdapters;
using Example_04.Adapters.Libs;
using Example_04.Adapters.ObjectAdapters;
using Example_04.Composites;

namespace Example_04
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //ITarget target;
            //target = new ClassAdapter();
            //target = new ClassAdapter1();

            //target = new ObjectAdapter(new MathHelper());
            //target = new ObjectAdapter(new MathHelper1());

            MenuExample();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void MenuExample()
        {
            var menu1 = new MenuContainer(new MenuComponent[]
            {
                new MenuLeaf("1. My profile"),
                new MenuComposite("2. Admin", new[]
                {
                    new MenuLeaf("2.1. Admin page")
                }),
                new MenuComposite("3. Lists", new MenuComponent[]
                {
                    new MenuLeaf("3.1. Admin page"),
                    new MenuLeaf("3.2. Lecturers"),
                    new MenuComposite("3.3 Students", new MenuComponent[]
                    {
                        new MenuComposite("3.3.1. 1-st year", new[]
                        {
                            new MenuLeaf("3.3.1.1. Computer science"),
                            new MenuLeaf("3.3.1.2. Mathematics"),
                            new MenuLeaf("3.3.1.3. Admin page")
                        }),
                        new MenuLeaf("3.3.2. 2-nd year")
                    })
                })
            });

            var menu2 = new MenuComposite("1. My second menu", new[]
            {
                new MenuLeaf("1.1. My profile"),
                new MenuLeaf("1.2. My settings"),
            });

            var menu3 = new MenuContainer(new[] {new MenuLeaf("1. My profile menu") });

            var menu4 = new MenuLeaf("1. My forth menu");

            var menus = new MenuComponent[] {menu1, menu2, menu3, menu4};
            foreach (var menu in menus)
            {
                Console.WriteLine(menu.Render());
                Console.WriteLine();
                Console.WriteLine(@"------");
                Console.WriteLine();
            }
        }
    }
}
