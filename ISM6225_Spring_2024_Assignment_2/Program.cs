﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check for null input to prevent Null Pointer Exception
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
                }

                // If the array is empty, return 0 as there are no unique elements
                if (nums.Length == 0)
                {
                    Console.WriteLine("The array is empty.");
                    return 0;
                }

                // Initialize uniqueIndex at 1 since the first element is always unique
                int uniqueIndex = 1;

                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is not equal to the previous one, it's unique
                    if (nums[i] != nums[i - 1])
                    {
                        // Move unique element to the next position in the unique portion of the array
                        nums[uniqueIndex] = nums[i];
                        // Increment uniqueIndex to expand the unique portion
                        uniqueIndex++;
                    }
                }

                // Print the modified array with unique elements followed by placeholders
                Console.Write("The modified array is: ");
                for (int i = 0; i < uniqueIndex; i++)
                {
                    Console.Write(nums[i] + " ");
                }
                // Fill the rest of the array with "*" to indicate removed duplicates
                for (int i = uniqueIndex; i < nums.Length; i++)
                {
                    Console.Write("*" + " ");
                }
                Console.WriteLine();

                // Print the total number of unique elements
                Console.Write("The Total Number of Unique Elements in the Array are: ");
                return uniqueIndex;
            }
            catch (Exception ex)
            {
                // Log the exception details or throw a custom exception if necessary
                throw new InvalidOperationException("An error occurred while removing duplicates.", ex);
            }
        }
        // Time Complexity: O(n), Space Complexity: O(1)

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check for null input to prevent NullReferenceException
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
                }

                // Initialize nonZeroIndex to keep track of the position to place the next non-zero element
                int nonZeroIndex = 0;

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, move it to the position indicated by nonZeroIndex
                    if (nums[i] != 0)
                    {
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++;
                    }
                }

                // After all non-zero elements have been moved to the beginning,
                // fill the remainder of the array with zeroes
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                Console.Write("Array after moving zeroes: ");
                // Return the modified array with zeroes moved to the end
                return nums;
            }
            catch (Exception ex)
            {
                // Log the exception details or throw a custom exception if necessary
                throw new InvalidOperationException("An error occurred while moving zeroes.", ex);
            }
        }
        // Time Complexity: O(n), Space Complexity: O(1)

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Check for null input to prevent Null Pointer Exception
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
                }

                // Sort the array to facilitate finding triplets and skipping duplicates.
                Array.Sort(nums);
                List<IList<int>> result = new List<IList<int>>();

                // Iterate over each number in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // Skip duplicate elements to avoid duplicate triplets.
                    if (i > 0 && nums[i] == nums[i - 1]) continue;

                    // Initialize two pointers for the current element.
                    int left = i + 1, right = nums.Length - 1;
                    while (left < right)
                    {
                        // Calculate the sum of the current triplet.
                        int currentSum = nums[i] + nums[left] + nums[right];

                        // If the sum is less than zero, increase the sum by moving the left pointer to the right.
                        if (currentSum < 0)
                        {
                            left++;
                            // If the sum is more than zero, decrease the sum by moving the right pointer to the left.
                        }
                        else if (currentSum > 0)
                        {
                            right--;
                        }
                        else
                        {
                            // A valid triplet that sums up to zero has been found.
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip all duplicate values for the left pointer.
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            // Skip all duplicate values for the right pointer.
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            // Prepare for the next iteration to find new triplets.
                            left++;
                            right--;
                        }
                    }
                }

                Console.Write("Triplets summing to zero: ");
                // Return the list of found triplets.
                return result;
            }
            catch (Exception ex)
            {
                // Properly handle exceptions by logging or throwing a more descriptive error.
                throw new InvalidOperationException("An error occurred while executing the ThreeSum algorithm.", ex);
            }
        }
        // Time Complexity: O(n^2), Space Complexity: O(logn) for sorting, additional space for result list

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Check for null input to ensure the method does not throw a NullReferenceException
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
                }

                // Initialize variables to track the maximum consecutive ones found and the current streak of ones.
                // Tracks the current streak of consecutive ones.
                int maxConsecutiveOnes = 0;
                // Stores the maximum streak found so far.
                int currentMax = 0; 

                // Iterate over each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is 1, increment the streak counter.
                    if (nums[i] == 1)
                    {
                        // Increment the current streak.
                        maxConsecutiveOnes++; 
                        // Update currentMax if the current streak is the new maximum.
                        if (maxConsecutiveOnes > currentMax)
                        {
                            currentMax = maxConsecutiveOnes;
                        }
                    }
                    else
                    {
                        // If the current element is not 1, reset the streak counter.
                        maxConsecutiveOnes = 0;
                    }
                }
                Console.Write("Maximum consecutive ones:");
                // Return the maximum streak of consecutive ones found in the array.
                return currentMax;
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions, providing a more informative message and context.
                throw new InvalidOperationException("An error occurred while finding the maximum consecutive ones.", ex);
            }
        }
        // Time Complexity: O(n), Space Complexity: O(1)

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Convert the binary integer to a string to iterate over each digit
                string input = binary.ToString();

                // Initialize the decimalNumber to store the decimal equivalent of the binary input
                int decimalNumber = 0;
                // Initialize baseValue to 1, representing the base value of the least significant bit (2^0)
                int baseValue = 1;

                // Iterate over the input string from right (least significant bit) to left (most significant bit)
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    // Check if the current character is '1'
                    if (input[i] == '1')
                    {
                        // If '1', add the current base value to decimalNumber
                        decimalNumber += baseValue;
                    }
                    // Double the base value for the next iteration to represent the next higher power of 2
                    baseValue *= 2;
                }
                Console.Write("Decimal value: ");
                return decimalNumber;
            }
            catch (Exception ex)
            {
                // Log the exception details or throw a custom exception if necessary.
                throw new InvalidOperationException("An error occurred while converting binary to decimal.", ex);
            }
        }
        // Time Complexity: O(n), Space Complexity: O(1)


        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Check for null input to ensure the method does not throw a NullReferenceException
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
                }
                if (nums.Length < 2)
                {
                    Console.Write("Maximum gap:");
                    return 0;
                }

                int max = nums[0];
                foreach (int num in nums)
                {
                    if (num > max) max = num;
                }

                // Arrays for Radix Sort
                int[] output = new int[nums.Length];
                int[] count = new int[10]; // Since we are dealing with decimal numbers

                // Start from the least significant digit and move towards the most significant
                for (int exp = 1; max / exp > 0; exp *= 10)
                {
                    Array.Fill(count, 0);

                    // Count occurrences of the current digit
                    for (int i = 0; i < nums.Length; i++)
                    {
                        count[(nums[i] / exp) % 10]++;
                    }

                    // Adjust count[i] so it contains the actual position of this digit in output[]
                    for (int i = 1; i < 10; i++)
                    {
                        count[i] += count[i - 1];
                    }

                    // Build the output array
                    for (int i = nums.Length - 1; i >= 0; i--)
                    {
                        output[count[(nums[i] / exp) % 10] - 1] = nums[i];
                        count[(nums[i] / exp) % 10]--;
                    }

                    // Copy the output array to nums, so nums now contains sorted numbers up to current digit
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = output[i];
                    }
                }

                // After sorting, find the maximum gap
                int maxGap = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                }

                Console.Write("Maximum gap:");
                // Return the maximum gap found
                return maxGap;
            }
            catch (Exception ex)
            {
                // Log the exception details or throw a custom exception if necessary.
                throw new InvalidOperationException("An unexpected error occurred while calculating the maximum gap.", ex);
            }
        }
        // Time Complexity: O(nk) which still is a linear time, Space Complexity: O(n)

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Check for a null or too small array to form a triangle.
                if (nums == null || nums.Length < 3)
                {
                    throw new ArgumentException("Array must contain at least three elements.", nameof(nums));
                }

                // Sort the array in ascending order to easily find the largest sides.
                Array.Sort(nums);

                Console.Write("Largest perimeter:");
                // Iterate from the end of the array towards the beginning to check for possible triangles.
                // Start from the third-last element, as we need at least three sides to form a triangle.
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current element and the two preceding it can form a triangle.
                    // A triangle is valid if the sum of the lengths of the two shorter sides is greater than the length of the longest side.
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                    {
                        // If a valid triangle is found, return its perimeter.
                        return nums[i] + nums[i - 1] + nums[i - 2];
                    }
                }

                // If no valid triangle can be formed, return 0.
                return 0;
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions, providing a more informative message and context.
                throw new InvalidOperationException("An error occurred while calculating the largest perimeter.", ex);
            }
        }
        // Time Complexity: O(n log n), Space Complexity: O(1)

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Check for null or empty inputs to ensure validity.
                if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(part))
                {
                    throw new ArgumentException("Input strings cannot be null or empty.");
                }

                // Index to store the position of 'part' in 's'.
                int index;

                // Continue the loop as long as 'part' is found in 's'.
                while ((index = s.IndexOf(part)) != -1)
                {
                    // Remove 'part' from 's' by concatenating the substring before 'part' and the substring after 'part'.
                    s = s.Substring(0, index) + s.Substring(index + part.Length);
                }

                Console.Write("String after removing occurrences:");
                // Return the modified string 's' after removing all occurrences of 'part'.
                return s;
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions, providing a more informative message and context.
                throw new InvalidOperationException("An error occurred while removing occurrences.", ex);
            }
        }
        // Time Complexity: O(n*m), Space Complexity: O(1)

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}