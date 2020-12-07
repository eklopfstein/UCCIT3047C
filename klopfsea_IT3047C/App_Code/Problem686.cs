/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 01                                                                *
 * Due: January 22nd 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * Solves Project Euler Problem 686 for the                                    *
 * Assignment01 page                                                           *
 * *****************************************************************************/

public class Problem686
{
    /// <summary>
    /// Solves Project Euler Problem 686
    /// Should only take a few seconds
    /// </summary>
    /// <returns>Ansrew for problem 686</returns>
    public int Solve()
    {
        // Since the given signature limits us to an int I avoided using BigInteger by
        // dividing by 10 each time the number exceeded 1000 because all I needed was the first 3 number 
        // to see if they were 123
        int exponent = 0; // Used to track how many times it has exponentially increased
        double result = 1; // Used to track result from current exponent
        int occurences = 0; // Used to track times the first 3 number were 123
        for (; occurences != 678910; exponent++)
        {
            result *= 2; // Exponentially increase the number 2
            if (result >= 1000) // If number is over or at 1000
            {
                result /= 10; // Divide by 10 to keep number small
            }
            if (result >= 123 && result < 124) // If the result is at or above 123 and at or below 123.99... 
            {
                occurences++; // Count the occurence of a number starting with 123
            }
        }
        return exponent; // Return exponent that returned 123 and the wanted number of occurences
    }
}