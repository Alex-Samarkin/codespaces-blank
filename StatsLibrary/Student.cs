namespace StatsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// class Student based on class Person with student-specific properties
public class Student : Person
{
    /// add attributes for student-specific properties
    [JsonProperty("studentId"),DisplayName("Student ID"),Description("Student ID"),Category("Student"),ReadOnly(true),Comment("Student ID")]
    public string StudentId { get; set; }
    [JsonProperty("major"),DisplayName("Major"),Description("Major"),Category("Student"),ReadOnly(false),Comment("Major")]
    public string Major { get; set; }
    /// GPA is a double
    [JsonProperty("gpa"),DisplayName("GPA"),Description("GPA"),Category("Student"),ReadOnly(false),Comment("GPA")]
    public double Gpa { get; set; }
    [JsonProperty("faculty"),DisplayName("Faculty"),Description("Faculty"),Category("Student"),ReadOnly(false),Comment("Faculty")]
    public string Faculty { get; set; }
    [JsonProperty("department"),DisplayName("Department"),Description("Department"),Category("Student"),ReadOnly(false),Comment("Department")]
    public string Department { get; set; }
    [JsonProperty("group"),DisplayName("Group"),Description("Group"),Category("Student"),ReadOnly(false),Comment("Group")]
    public string Group { get; set; }
    [JsonProperty("course"),DisplayName("Course"),Description("Course"),Category("Student"),ReadOnly(false),Comment("Course")]
    public string Course { get; set; }

    public Student(string firstName, string lastName, string email, string phoneNumber, string address, string city, string state, string zipCode, 
    string studentId, string major, double gpa, string Faculty, string Department, string Group, string Course
    ) : base(firstName, lastName, email, phoneNumber, address, city, state, zipCode)
    {
        StudentId = studentId;
        Major = major;
        Gpa = gpa;
        this.Faculty = Faculty;
        this.Department = Department;
        this.Group = Group;
    }

    public Student() : base()
    {
        StudentId = "";
        Major = "";
        Gpa = 0.0;
        Faculty = "";
        Department = "";
        Group = "";
        Course = "";
    }

    /// constructor based on Person
    public Student(Person person) : base(person)
    {
        StudentId = "";
        Major = "";
        Gpa = 0.0;
        Faculty = "";
        Department = "";
        Group = "";
        Course = "";
    }
    /// constructor based on Person with student-specific properties
    public Student(Person person, string studentId, string major, double gpa, string Faculty, string Department, string Group, string Course) : base(person)
    {
        StudentId = studentId;
        Major = major;
        Gpa = gpa;
        this.Faculty = Faculty;
        this.Department = Department;
        this.Group = Group;
        this.Course = Course;
    }

    /// copy constructor
    public Student(Student student) : base(student)
    {
        StudentId = student.StudentId;
        Major = student.Major;
        Gpa = student.Gpa;
    }

    /// equality operator
    public static bool operator ==(Student student1, Student student2)
    {
        return student1.Equals(student2);
    }

    /// inequality operator
    public static bool operator !=(Student student1, Student student2)
    {
        return !student1.Equals(student2);
    }

    /// override Equals
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        Student student = (Student)obj;
        return base.Equals(student) && StudentId == student.StudentId && Major == student.Major && Gpa == student.Gpa;
    }

    /// override GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode() ^ StudentId.GetHashCode() ^ Major.GetHashCode() ^ Gpa.GetHashCode();
    }

    /// override ToString
    public override string ToString()
    {
        return $"{base.ToString()} {StudentId} {Major} {Gpa}";
    }
}
