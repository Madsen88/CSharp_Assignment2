using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_Assignment2.Models
{
    [Serializable]
    public class Submission : ISerializable
    {
        public const string PATH = @"MyClassLibrary\Submissions.txt";
        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public DateTime DOB { get; set; }
        public string SerialNumber { get; set; }

        public Submission(string firstname, string surname, string email, string phonenumber, DateTime dob,
            string serialnumber)
        {
            FirstName = firstname;
            Surname = surname;
            Email = email;
            Phonenumber = phonenumber;
            DOB = dob.Date;
            SerialNumber = serialnumber;
        }

        public Submission(SerializationInfo info, StreamingContext context)
        {
            FirstName = (string) info.GetValue("FirstName", typeof(string));
            Surname = (string) info.GetValue("Surname", typeof(string));
            Email = (string) info.GetValue("Email", typeof(string));
            Phonenumber = (string) info.GetValue("Phonenumber", typeof(string));
            DOB = (DateTime) info.GetValue("DOB", typeof(DateTime));
            SerialNumber = (string) info.GetValue("SerialNumber", typeof(string));
        }

        

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("Surname", Surname);
            info.AddValue("Email", Email);
            info.AddValue("Phonenumber", Phonenumber);
            info.AddValue("DOB", DOB);
            info.AddValue("SerialNumber", SerialNumber);
        }

        public override string ToString()
        {
            return
                $"{nameof(FirstName)}: {FirstName}, {nameof(Surname)}: {Surname}, {nameof(Email)}: {Email}, {nameof(Phonenumber)}: {Phonenumber}, {nameof(DOB)}: {DOB}, {nameof(SerialNumber)}: {SerialNumber}";
        }

        public void SaveSubmissionToFile(Submission obj)
        {
            Stream stream;
            try
            {
                stream = File.Open(PATH, FileMode.Append);
                var bf = new BinaryFormatter();

                bf.Serialize(stream, obj);
                stream.Close();
            }
            catch (Exception)
            {
                //todo Fix Exception handling
                throw;
            }
        }

        public static ICollection<Submission> ReadSubmissionsFromFile(string Path)
        {
            Stream stream = File.Open(Path, FileMode.Open);
            var bf = new BinaryFormatter();
            var list = new List<Submission>();
            while (stream.Position != stream.Length)
            {
                //deserialize
                var deserialized = (Submission) bf.Deserialize(stream);
                //add to list
                list.Add(deserialized);
            }
            stream.Close();
            return list;
        }
    }
}