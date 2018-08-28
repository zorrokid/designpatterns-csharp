using Creational.Builder;
using Creational.BuilderInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // ordinary non-fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            // fluent builder
            builder.Clear(); // disengage builder from the object it's building, then...
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            Console.WriteLine(builder);

            // BUILDER INHERITANCE DEMO


            var person =
                Person.New
                    .Called("Mikko")
                    .WorksAsA("Software Developer")
                    .Build();
            Console.WriteLine(person);

        }
    }
}
