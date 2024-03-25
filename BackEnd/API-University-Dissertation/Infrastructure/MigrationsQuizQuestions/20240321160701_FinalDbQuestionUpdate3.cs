using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class FinalDbQuestionUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "Question", "QuestionTypeId" },
                values: new object[,]
                {
                    { 1, "The best case time complexity of bubble sort is _______?", 1 },
                    { 2, "What is the worst case time complexity of bubble sort?", 1 },
                    { 3, "What is the space complexity of bubble sort?", 1 },
                    { 4, "What is the best case time complexity of selection sort?", 1 },
                    { 5, "What is the worst case time complexity of selection sort?", 1 },
                    { 6, "What is the space complexity of selection sort?", 1 },
                    { 7, "What is the best case time complexity of insertion sort?", 1 },
                    { 8, "What is the worst case time complexity of insertion sort?", 1 },
                    { 9, "The space complexity of insertion sort is ________", 1 },
                    { 10, "What is the best case time complexity of Merge sort?", 1 },
                    { 11, "What is the worst case time complexity of Merge sort?", 1 },
                    { 12, "What is the space complexity of Merge sort?", 1 },
                    { 13, "What is the best case time complexity of quick sort?", 1 },
                    { 14, "The worst case time complexity of quick sort is ______", 1 },
                    { 15, "What is the space complexity of quick sort?", 1 },
                    { 16, "What is the best case time complexity of shell sort?", 1 },
                    { 17, "What is the worst case time complexity of shell sort?", 1 },
                    { 18, "What is the space complexity of shell sort?", 1 },
                    { 19, "The ascending motion of bubbles in fizzy water symbolises _________ in Bubble Sort?", 2 },
                    { 20, "What is the main limitation of Selection Sort?", 2 },
                    { 21, "Which enhanced version of Selection Sort addresses its limitations and improves performance?", 2 },
                    { 22, "What happens during the merging phase of Merge Sort?", 2 },
                    { 23, "Merge Sort employs the technique of ________ to sort elements?", 2 },
                    { 24, "Shell Sort is an extension of which sorting algorithm?", 2 },
                    { 25, "What is the main purpose of initiating comparisons between distant elements in Shell Sort?", 2 },
                    { 26, "Which searching algorithm works efficiently only on sorted arrays?", 3 },
                    { 27, "The data structure _______ is typically applied to Binary search.", 3 },
                    { 28, "Which searching algorithm is based on the principle of repeatedly dividing the search interval in half?", 3 },
                    { 29, "______ is the primary advantage of binary search over linear search?", 3 },
                    { 30, "In which situation might linear search outperform binary search?", 3 },
                    { 31, "True or False: Depth-First Search (DFS) is commonly used to find the shortest path between two nodes in a graph", 3 },
                    { 32, "True or False: Binary search is more efficient than linear search for unsorted arrays", 3 }
                });

            migrationBuilder.InsertData(
                table: "QuestionChoices",
                columns: new[] { "ID", "Choice", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "O(n)", true, 1 },
                    { 2, "O(1)", false, 1 },
                    { 3, "O(n^2)", false, 1 },
                    { 4, "O(n x log n)", false, 1 },
                    { 5, "O(n^2)", true, 2 },
                    { 6, "O(1)", false, 2 },
                    { 7, "O(n x log n)", false, 2 },
                    { 8, "O(n)", false, 2 },
                    { 9, "O(1)", true, 3 },
                    { 10, "O(n^2)", false, 3 },
                    { 11, "O(n x log n)", false, 3 },
                    { 12, "O(n)", false, 3 },
                    { 13, "O(n^2)", true, 4 },
                    { 14, "O(1)", false, 4 },
                    { 15, "O(n x log n)", false, 4 },
                    { 16, "O(n)", false, 4 },
                    { 17, "O(n)", true, 5 },
                    { 18, "O(1)", false, 5 },
                    { 19, "O(n^2)", false, 5 },
                    { 20, "O(n x log n)", false, 5 },
                    { 21, "O(1)", true, 6 },
                    { 22, "O(n^2)", false, 6 },
                    { 23, "O(n x log n)", false, 6 },
                    { 24, "O(n)", false, 6 },
                    { 25, "O(n^2)", false, 7 },
                    { 26, "O(1)", false, 7 },
                    { 27, "O(n x log n)", false, 7 },
                    { 28, "O(n^2)", true, 8 },
                    { 29, "O(1)", false, 8 },
                    { 30, "O(n x log n)", false, 8 },
                    { 31, "O(n)", false, 8 },
                    { 32, "O(1)", true, 9 },
                    { 33, "O(n^2)", false, 9 },
                    { 34, "O(n x log n)", false, 9 },
                    { 35, "O(n)", false, 9 },
                    { 36, "O(n x log n)", true, 10 },
                    { 37, "O(n)", false, 10 },
                    { 38, "O(n^2)", false, 10 },
                    { 39, "O(1)", false, 10 },
                    { 40, "O(n x log n)", true, 11 },
                    { 41, "O(n^2)", false, 11 },
                    { 42, "O(n)", false, 11 },
                    { 43, "O(1)", false, 11 },
                    { 44, "O(n x log n)", false, 12 },
                    { 45, "O(n^2)", false, 12 },
                    { 46, "O(1)", false, 12 },
                    { 47, "O(n)", true, 12 },
                    { 48, "O(n x log n)", true, 13 },
                    { 49, "O(n^2)", false, 13 },
                    { 50, "O(n)", false, 13 },
                    { 51, "O(1)", false, 13 },
                    { 52, "O(n^2)", true, 14 },
                    { 53, "O(n x log n)", false, 14 },
                    { 54, "O(n)", false, 14 },
                    { 55, "O(1)", false, 14 },
                    { 56, "O(n)", true, 15 },
                    { 57, "O(n^2)", false, 15 },
                    { 58, "O(1)", false, 15 },
                    { 59, "O(n x log n)", false, 15 },
                    { 60, "O(n^2)", false, 16 },
                    { 61, "O(1)", false, 16 },
                    { 62, "O(n x log n)", true, 16 },
                    { 63, "O(n)", false, 16 },
                    { 64, "O(n^2)", true, 17 },
                    { 65, "O(1)", false, 17 },
                    { 66, "O(n x log n)", false, 17 },
                    { 67, "O(n)", false, 17 },
                    { 68, "O(n^2)", false, 18 },
                    { 69, "O(1)", true, 18 },
                    { 70, "O(n x log n)", false, 18 },
                    { 71, "O(n)", false, 18 },
                    { 72, "O(n)", true, 7 },
                    { 73, "Elements moving to the bottom of the array", false, 19 },
                    { 74, "Elements moving to the top of the array", true, 19 },
                    { 75, "Elements remaining stationary", false, 19 },
                    { 76, "Elements being randomly rearranged", false, 19 },
                    { 77, "It requires additional memory", false, 20 },
                    { 78, "It has a high space complexity", false, 20 },
                    { 79, "Its time complexity is not well-defined", false, 20 },
                    { 80, "Its quadratic time complexity makes it inefficient for large data structures", true, 20 },
                    { 81, "Quick Sort", false, 21 },
                    { 82, "Merge Sort", false, 21 },
                    { 83, "Heap Sort", true, 21 },
                    { 84, "Insertion Sort", false, 21 },
                    { 85, "Unsorted subsequences are combined into a single sorted sublist", true, 22 },
                    { 86, "Elements are divided into smaller sublists recursively", false, 22 },
                    { 87, "Adjacent elements are compared and swapped if necessary", false, 22 },
                    { 88, "The largest element is selected and appended to the sorted sublist", false, 22 },
                    { 89, "Divide and conquer", true, 23 },
                    { 90, "Greedy algorithm", false, 23 },
                    { 91, "Dynamic programming", false, 23 },
                    { 92, "Backtracking", false, 23 },
                    { 93, "Bubble Sort", false, 24 },
                    { 94, "Merge Sort", false, 24 },
                    { 95, "Insertion Sort", true, 24 },
                    { 96, "Quick Sort", false, 24 },
                    { 97, "To increase memory usage", false, 25 },
                    { 98, "To decrease time complexity", false, 25 },
                    { 99, "To avoid the limitations of comparing only adjacent elements", true, 25 },
                    { 100, "To increase the number of comparisons", false, 25 },
                    { 101, "Linear Search", false, 26 },
                    { 102, "Binary Search", true, 26 },
                    { 103, "Depth-First Search", false, 26 },
                    { 104, "Breadth-First Search", false, 26 },
                    { 105, "Array", true, 27 },
                    { 106, "Linked List", false, 27 },
                    { 107, "Hash Table", false, 27 },
                    { 108, "Stack", false, 27 },
                    { 109, "Linear Search", false, 28 },
                    { 110, "Binary Search", true, 28 },
                    { 111, "Interpolation Search", false, 28 },
                    { 112, "Depth-First Search", false, 28 },
                    { 113, "Binary search is easier to implement", false, 29 },
                    { 114, "Binary search works efficiently on unsorted arrays", false, 29 },
                    { 115, "Binary search has a lower time complexity", true, 29 },
                    { 116, "Binary search requires less memory.", false, 29 },
                    { 117, "When the array is sorted in descending order", false, 30 },
                    { 118, "When the array is extremely large", false, 30 },
                    { 119, "When the array is unsorted and has a small number of elements", true, 30 },
                    { 120, "When the array is sparse", false, 30 },
                    { 121, "True", false, 31 },
                    { 122, "False", true, 31 },
                    { 123, "True", false, 32 },
                    { 124, "False", true, 32 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "QuestionChoices",
                keyColumn: "ID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
