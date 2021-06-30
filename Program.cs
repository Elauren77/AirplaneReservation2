using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSeats
{
    partial class Program
    {
         public enum SeatPosition 
         {
            Window = 0, 
            Middle = 1,
            Aisle = 2  
        }
       public struct Seat {
           public string SeatNumber;
           public SeatPosition SeatPosition;
           public bool IsAvailable;
           }

       public class Plane 
       {
          public const int RowCount = 10; 
          public const int SeatsPerRow = 6;
          public const int SeatCount = RowCount * SeatsPerRow;
          public string TailNumber = "NN8042";
          public string FlightNumber = "1";
          public Seat[] Seats = new Seat[SeatCount];  // "Array-of-seat-structs 60 of them" 
        
          public Plane() {

              string[] SeatLetters = {"A", "B", "C", "D", "E", "F"};  // "Array-of-strings 60 of them"
              for (int i = 0; i < SeatCount; i++)
               {
                  string seatLetter = SeatLetters[i % SeatsPerRow];
                  Seats[i].SeatNumber = $"{i / SeatsPerRow + 1}{seatLetter}";
                  Seats[i].SeatPosition = ((SeatPosition) (Math.Min ( i % SeatsPerRow, (SeatsPerRow - 1) - (i % SeatsPerRow) )));
                  Seats[i].IsAvailable  = true; 
                }


            } 
          public void PrintAvailableSeats() {
              Console.WriteLine("This Seat Available");
              foreach(Seat seat in Seats) {

                  if (seat.IsAvailable) {
                      Console.WriteLine($"{seat.SeatNumber} : {seat.SeatPosition}");
                    }
                }
            }
        }  
        static void Main(string[] args)
        {
            Plane NelnetPrivatePlane = new Plane(); 
            for (int i = 0; i < NelnetPrivatePlane.Seats.Length; i++)
            {
               if (NelnetPrivatePlane.Seats[i].SeatPosition == SeatPosition.Aisle)
                {
                 NelnetPrivatePlane.Seats[i].IsAvailable = false;
                }
             NelnetPrivatePlane.PrintAvailableSeats();
            }
        }
    }
}
