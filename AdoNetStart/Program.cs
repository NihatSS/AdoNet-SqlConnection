
using AdoNetStart.Datas;
using AdoNetStart.Models;
using Microsoft.Data.SqlClient;

AppDbContext context = new AppDbContext();

void GetAllStudents()
{
    context.CheckConnection();

    SqlCommand cmd = new("SELECT * FROM Students",context.connection);

    SqlDataReader reader = cmd.ExecuteReader();

    List<Student> students = new();
    while (reader.Read())
    {
        students.Add(new Student 
        { 
            Id = Convert.ToInt32(reader["Id"]),
            FullName = reader["FullName"].ToString(),
            Age = Convert.ToInt32(reader["Age"])
        });
    }

    context.connection.Close();
    reader.Close();

    foreach (var student in students)
    {
        Console.WriteLine($"{student.Id} {student.FullName} {student.Age}");
    }
}



void CreateStudent(Student student)
{
    context.CheckConnection();

    SqlCommand cmd = new("INSERT INTO Students([FullName],[Age]) values(@fullName,@age)",context.connection);
    cmd.Parameters.AddWithValue("@fullName",student.FullName);
    cmd.Parameters.AddWithValue("@age",student.Age);

    int rowAffected = cmd.ExecuteNonQuery();

    if (rowAffected > 0)
    {
        Console.WriteLine("Data succesfully created");
    }

    context.connection.Close();
}

void DeleteStudentById(int id)
{
    context.CheckConnection();
    SqlCommand cmd = new("DELETE FROM Students WHERE [Id] = @id",context.connection);
    cmd.Parameters.AddWithValue("@id",id);

    int rowAffected = cmd.ExecuteNonQuery();

    if (rowAffected > 0)
    {
        Console.WriteLine("Data succesfully Deleted");
    }

    context.connection.Close();
}

Console.WriteLine("Enter the id of student:");
Number: string studetId = Console.ReadLine();

bool isCorrectNumFormat = int.TryParse(studetId, out int correctNum);
if (isCorrectNumFormat)
{
    DeleteStudentById(correctNum);
    GetAllStudents();
}
else
{
    Console.WriteLine("Inavild number format! Add again:");
    goto Number;
}



//Console.WriteLine("Enter the student's fullname:");
//string fullName = Console.ReadLine();

//Console.WriteLine("Add student's age:");
//int Age = Convert.ToInt32(Console.ReadLine());


//CreateStudent(new Student { FullName = fullName, Age = Age });

//Console.WriteLine("------------------------------------");

//GetAllStudents();

//int c = 100;

//void Test(out int a)
//{
//    a = 400;

//    Console.WriteLine(a);
//}

//Test(out c);

//Console.WriteLine("Add number:");
//Number: string num = Console.ReadLine();

//bool isCorrectNumFormat = int.TryParse(num, out int correctNum);
//if (isCorrectNumFormat)
//{
//    Console.WriteLine("Number is " + num);
//}
//else
//{
//    Console.WriteLine("Inavild number format! Add again:");
//    goto Number;
//}

