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
                                      .AddQueryType<FindStudent>();



            var app = builder.Build();


            // AddGraghQL Endpoint
            app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());


            app.MapGet("/", () => "Hello World!");

            app.Run();



        }
        //Build a data record/dataset
        public record Student(string Name, String Program);
        public record Instrutor(string Name, String Program);

        // Build a query
        public class FindStudent
        {
            readonly List<Student> _students = new()
            {
                new Student ("Nick", "Doctorate"),
                new Student ("Carlos", "Emeritus")
            };
            // Build a query
            public List<Student> GetStudents() => _students;

        }



    }
}
