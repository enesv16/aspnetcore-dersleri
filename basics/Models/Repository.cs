namespace basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new();

        static Repository()
        {
            _courses = new List<Course>()
            {
                new Course() {
                    Id =1,
                    Title="C++ Kursu",
                    Description="C++ ile bir çok hayal gercek olur.",
                    Image="4.jpg",
                    Tags= new string[]{"C++","ConsoleApp"},
                    isActive= true,
                    isHome=true
                  },
                new Course() {
                    Id =2,
                    Title="Php Kursu",
                    Description="Php ile bir çok hayal gercek olur.",
                    Image="2.jpg",
                    Tags= new string[]{"Php","WebApp"},
                    isActive= true,
                    isHome=true
                    },
                new Course() {
                    Id =3,
                    Title="Aspnet Kursu",
                    Description="Aspnet ile bir çok hayal gercek olur.",
                    Image="1.jpg",
                    isActive= true,
                    isHome=true
                },
                new Course() {
                    Id = 4,
                    Title = "Python Kursu",
                    Description = "Python ile bir çok hayal gercek olur.",
                    Image = "3.jpg",
                    Tags = new string[] { "Python", "ConsoleApp" },
                    isActive = true,
                    isHome = true
                }
            };
        }

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        public static Course? GetCourseById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}