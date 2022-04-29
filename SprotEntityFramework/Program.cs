using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var Group = new Group()
                {
                    Name = "Rammstain",
                    Year = 1994
                };
                var Group2 = new Group()
                {
                    Name = "Linkin Park",
                };

                context.Groups.Add(Group);
                context.Groups.Add(Group2);
                context.SaveChanges();

                var songs = new List<Song>
                {
                    new Song() {Name = "In The End", GroupId = Group2.Id}, 
                    new Song() {Name = "NUmb", GroupId = Group2.Id},
                    new Song() {Name = "Mutter", GroupId = Group.Id} ,
                };
                context.Songs.AddRange(songs);
                context.SaveChanges();

                foreach (var song in songs)

                Console.WriteLine($"Id: {song.Id}, Song Name: {song.Name},Group name: {song.Group?.Name}");
                Console.ReadLine();
            }


        }
    }
}
