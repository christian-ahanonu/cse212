public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: I'll create an empty array for storing values 
        double[] result = new double[length];

        // Step 2: Loop through the array  
        for (int i = 0; i < length; i++)
        {
            // Step 3: Mutiply each number by (i + 1) to get all the multiples
            result[i] = number * (i + 1);

        }

        // Step 4: Return the completed array of multiples
        return result;
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Using the GetRange method I will extract the last
        // amount in the list
        List<int> lastItems = data.GetRange(data.Count - amount, amount);

        // Step 2: With the RemoveRange method I will remove these identified 
        // amounts from their position 
        data.RemoveRange(data.Count - amount, amount);

        // Step 3: Lastly, I will insert the removed items to the beginning of the list.
        // This will complete the rotation of the list by the amount specified.
        data.InsertRange(0, lastItems);


    }
}