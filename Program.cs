using static GraphQLDemo.Program;
namespace GraphQLDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add A graphql sercive
            builder.Services.AddGraphQLServer()
                                      .AddQueryType<FindStudent>()
                                      .AddMutationType<Mutation>();

            var app = builder.Build();

            // AddGraghQL Endpoint
            app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
        //Build a data record/dataset
        public record Student(string FirstName, string LastName, string Gender, int Age, string Program);

        public record Instrutor(string Name, string Program);

        // Build a query
        public class FindStudent
        {
            readonly List<Student> _students = new()
            {
                new Student ("Arvind", "Pandit","M", 38, "BAIST-IS"),
                new Student ("Carlos", "Marquez","M", 27, "BAIST-IS"),
                new Student ("Evan", "Keefe","M", 25, "BAIST-IS"),
                new Student ("Ezra", "Mallo","M", 38, "BAIST-IS"),
                new Student ("Gunooor", "Randhawa","M", 22, "BAIST-IS"),
                new Student ("Nicholas", "Ekwom","M", 17, "BAIST-IS"),
                new Student ("Noelyn", "Yamat","F", 28, "BAIST-IS")
            };
            // Build a query
            public List<Student> GetStudents() => _students;
            public List<Student> GetStudentsWithAgeLessThan25() => _students.Where(student => student.Age < 25).ToList();
        }


        //buid Mutation
        public class Mutation
        {
            private readonly List<Student> _students = new List<Student>();

            public Student AddNewStudent(string firstName, string lastName, string gender, int age, string program)
            {
                var newStudent = new Student(firstName, lastName, gender, age, program);
                _students.Add(newStudent);

                return newStudent;
            }
        }

    }
}

