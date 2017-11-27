using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace CSharp_Assignment2.Models
{
    [Serializable()]
    public class Submission : ISerializable
    {
        private const string PATH = @"Models\Submissions.txt";

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phonenumber { get; set; }
        public DateTime DOB { get; set; }
        public int SerialNumber { get; set; }


        public Submission(string firstname, string surname, string email, int phonenumber, DateTime dob, int serialnumber)
        {
            FirstName = firstname;
            Surname = surname;
            Email = email;
            Phonenumber = phonenumber;
            DOB = dob.Date;
            SerialNumber = serialnumber;
            SaveSubmissionToFile(this);
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(Surname)}: {Surname}, {nameof(Email)}: {Email}, {nameof(Phonenumber)}: {Phonenumber}, {nameof(DOB)}: {DOB}, {nameof(SerialNumber)}: {SerialNumber}";
        }

        private void SaveSubmissionToFile(Submission obj)
        {
            Stream stream;
            try
            {
                stream = File.Open(PATH, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(stream, obj);
                stream.Close();
            }
            catch (Exception)
            {
                //todo Fix Exception handling
                throw;
            }
        }

        private ICollection<Submission> ReadSubmissionsFromFile(string Path)
        {
            Stream stream = File.Open(Path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Submission> list = new List<Submission>();
            while (stream.Position != stream.Length)
            {
                //deserialize each object in the file
                var deserialized = (Submission)bf.Deserialize(stream);
                //add individual object to a list
                list.Add(deserialized);
            }
            //return the list of objects
            return list;
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
        public Submission(SerializationInfo info, StreamingContext context)
        {
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            Surname = (string)info.GetValue("SurNanm", typeof(string));
            Email = (string)info.GetValue("Email", typeof(string));
            Phonenumber = (int)info.GetValue("Phonenumber", typeof(int));
            DOB = (DateTime)info.GetValue("DOB", typeof(DateTime));
            SerialNumber = (int)info.GetValue("SerialNumber", typeof(int));

        }


    }
}
