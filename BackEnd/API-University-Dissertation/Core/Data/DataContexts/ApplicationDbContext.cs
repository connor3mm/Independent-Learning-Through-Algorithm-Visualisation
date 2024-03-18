using API_University_Dissertation.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<ProficiencyLevel> ProficiencyLevels { get; set; }
    public DbSet<UserQuizStatistics> UserQuizStatistics { get; set; }
    public DbSet<QuizQuestions> QuizQuestions { get; set; }
    public DbSet<QuestionChoices> QuestionChoices { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType { Id = 1, Type = "Complexity" },
            new QuestionType { Id = 2, Type = "Sorting Algorithms" },
            new QuestionType { Id = 3, Type = "Searching Algorithms" }
        );

        modelBuilder.Entity<ProficiencyLevel>().HasData(
            new ProficiencyLevel { LevelId = 1, LevelName = "Undetermined" },
            new ProficiencyLevel { LevelId = 2, LevelName = "Beginner" },
            new ProficiencyLevel { LevelId = 3, LevelName = "Intermediate" },
            new ProficiencyLevel { LevelId = 4, LevelName = "Advanced" },
            new ProficiencyLevel { LevelId = 5, LevelName = "Expert" }
        );
        modelBuilder.Entity<QuizQuestions>().HasData(
            //Complexity Questions Seeding 
            new QuizQuestions
                { Id = 1, Question = "What is the best case time complexity of bubble sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 2, Question = "What is the worst case time complexity of bubble sort?", QuestionTypeId = 1 },
            new QuizQuestions { Id = 3, Question = "What is the space complexity of bubble sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 4, Question = "What is the best case time complexity of selection sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 5, Question = "What is the worst case time complexity of selection sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 6, Question = "What is the space complexity of selection sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 7, Question = "What is the best case time complexity of insertion sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 8, Question = "What is the worst case time complexity of insertion sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 9, Question = "What is the space complexity of insertion sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 10, Question = "What is the best case time complexity of Merge sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 11, Question = "What is the worst case time complexity of Merge sort?", QuestionTypeId = 1 },
            new QuizQuestions { Id = 12, Question = "What is the space complexity of Merge sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 13, Question = "What is the best case time complexity of quick sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 14, Question = "What is the worst case time complexity of quick sort?", QuestionTypeId = 1 },
            new QuizQuestions { Id = 15, Question = "What is the space complexity of quick sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 16, Question = "What is the best case time complexity of shell sort?", QuestionTypeId = 1 },
            new QuizQuestions
                { Id = 17, Question = "What is the worst case time complexity of shell sort?", QuestionTypeId = 1 },
            new QuizQuestions { Id = 18, Question = "What is the space complexity of shell sort?", QuestionTypeId = 1 },
            //Sorting Questions Seeding 
            new QuizQuestions
            {
                Id = 19,
                Question = "What does the ascending motion of bubbles in fizzy water symbolise in Bubble Sort?",
                QuestionTypeId = 2
            },
            new QuizQuestions
                { Id = 20, Question = "What is the main limitation of Selection Sort?", QuestionTypeId = 2 },
            new QuizQuestions
            {
                Id = 21,
                Question =
                    "Which enhanced version of Selection Sort addresses its limitations and improves performance?",
                QuestionTypeId = 2
            },
            new QuizQuestions
                { Id = 22, Question = "What happens during the merging phase of Merge Sort?", QuestionTypeId = 2 },
            new QuizQuestions
                { Id = 23, Question = "Merge Sort employs which technique to sort elements?", QuestionTypeId = 2 },
            new QuizQuestions
                { Id = 24, Question = "Shell Sort is an extension of which sorting algorithm?", QuestionTypeId = 2 },
            new QuizQuestions
            {
                Id = 25,
                Question = "What is the main purpose of initiating comparisons between distant elements in Shell Sort?",
                QuestionTypeId = 2
            },
            //Searching Questions Seeding 
            new QuizQuestions
            {
                Id = 26,
                Question = "Which searching algorithm works efficiently only on sorted arrays?",
                QuestionTypeId = 3
            },
            new QuizQuestions
            {
                Id = 27,
                Question = "In which data structure is binary search typically applied?",
                QuestionTypeId = 3
            },
            new QuizQuestions
            {
                Id = 28,
                Question =
                    "Which searching algorithm is based on the principle of repeatedly dividing the search interval in half?",
                QuestionTypeId = 3
            },
            new QuizQuestions
            {
                Id = 29,
                Question = "What is the primary advantage of binary search over linear search?",
                QuestionTypeId = 3
            },
            new QuizQuestions
            {
                Id = 30,
                Question = "In which situation might linear search outperform binary search?",
                QuestionTypeId = 3
            }, new QuizQuestions
            {
                Id = 31,
                Question =
                    "True or False: Depth-First Search (DFS) is commonly used to find the shortest path between two nodes in a graph",
                QuestionTypeId = 3
            }, new QuizQuestions
            {
                Id = 32,
                Question = "True or False: Binary search is more efficient than linear search for unsorted arrays",
                QuestionTypeId = 3
            }
        );

        modelBuilder.Entity<QuestionChoices>().HasData(
            new QuestionChoices
                { ID = 1, QuestionId = 1, Choice = "O(n)", IsCorrect = true },
            new QuestionChoices { ID = 2, QuestionId = 1, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 3, QuestionId = 1, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 4, QuestionId = 1, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 5, QuestionId = 2, Choice = "O(n^2)", IsCorrect = true },
            new QuestionChoices { ID = 6, QuestionId = 2, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 7, QuestionId = 2, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 8, QuestionId = 2, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 9, QuestionId = 3, Choice = "O(1)", IsCorrect = true },
            new QuestionChoices { ID = 10, QuestionId = 3, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 11, QuestionId = 3, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 12, QuestionId = 3, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 13, QuestionId = 4, Choice = "O(n^2)", IsCorrect = true },
            new QuestionChoices { ID = 14, QuestionId = 4, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 15, QuestionId = 4, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 16, QuestionId = 4, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 17, QuestionId = 5, Choice = "O(n)", IsCorrect = true },
            new QuestionChoices { ID = 18, QuestionId = 5, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 19, QuestionId = 5, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 20, QuestionId = 5, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 21, QuestionId = 6, Choice = "O(1)", IsCorrect = true },
            new QuestionChoices { ID = 22, QuestionId = 6, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 23, QuestionId = 6, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 24, QuestionId = 6, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 25, QuestionId = 7, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 26, QuestionId = 7, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 27, QuestionId = 7, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 28, QuestionId = 8, Choice = "O(n^2)", IsCorrect = true },
            new QuestionChoices { ID = 29, QuestionId = 8, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 30, QuestionId = 8, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 31, QuestionId = 8, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 32, QuestionId = 9, Choice = "O(1)", IsCorrect = true },
            new QuestionChoices { ID = 33, QuestionId = 9, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 34, QuestionId = 9, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 35, QuestionId = 9, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 36, QuestionId = 10, Choice = "O(n x log n)", IsCorrect = true },
            new QuestionChoices { ID = 37, QuestionId = 10, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 38, QuestionId = 10, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 39, QuestionId = 10, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 40, QuestionId = 11, Choice = "O(n x log n)", IsCorrect = true },
            new QuestionChoices { ID = 41, QuestionId = 11, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 42, QuestionId = 11, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 43, QuestionId = 11, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 44, QuestionId = 12, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 45, QuestionId = 12, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 46, QuestionId = 12, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 47, QuestionId = 12, Choice = "O(n)", IsCorrect = true },
            new QuestionChoices { ID = 48, QuestionId = 13, Choice = "O(n x log n)", IsCorrect = true },
            new QuestionChoices { ID = 49, QuestionId = 13, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 50, QuestionId = 13, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 51, QuestionId = 13, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 52, QuestionId = 14, Choice = "O(n^2)", IsCorrect = true },
            new QuestionChoices { ID = 53, QuestionId = 14, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 54, QuestionId = 14, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 55, QuestionId = 14, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 56, QuestionId = 15, Choice = "O(n)", IsCorrect = true },
            new QuestionChoices { ID = 57, QuestionId = 15, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 58, QuestionId = 15, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 59, QuestionId = 15, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 60, QuestionId = 16, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 61, QuestionId = 16, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 62, QuestionId = 16, Choice = "O(n x log n)", IsCorrect = true },
            new QuestionChoices { ID = 63, QuestionId = 16, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 64, QuestionId = 17, Choice = "O(n^2)", IsCorrect = true },
            new QuestionChoices { ID = 65, QuestionId = 17, Choice = "O(1)", IsCorrect = false },
            new QuestionChoices { ID = 66, QuestionId = 17, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 67, QuestionId = 17, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 68, QuestionId = 18, Choice = "O(n^2)", IsCorrect = false },
            new QuestionChoices { ID = 69, QuestionId = 18, Choice = "O(1)", IsCorrect = true },
            new QuestionChoices { ID = 70, QuestionId = 18, Choice = "O(n x log n)", IsCorrect = false },
            new QuestionChoices { ID = 71, QuestionId = 18, Choice = "O(n)", IsCorrect = false },
            new QuestionChoices { ID = 72, QuestionId = 7, Choice = "O(n)", IsCorrect = true },
            new QuestionChoices
                { ID = 73, QuestionId = 19, Choice = "Elements moving to the bottom of the array", IsCorrect = false },
            new QuestionChoices
                { ID = 74, QuestionId = 19, Choice = "Elements moving to the top of the array", IsCorrect = true },
            new QuestionChoices
                { ID = 75, QuestionId = 19, Choice = "Elements remaining stationary", IsCorrect = false },
            new QuestionChoices
                { ID = 76, QuestionId = 19, Choice = "Elements being randomly rearranged", IsCorrect = false },
            new QuestionChoices
                { ID = 77, QuestionId = 20, Choice = "It requires additional memory", IsCorrect = false },
            new QuestionChoices
                { ID = 78, QuestionId = 20, Choice = "It has a high space complexity", IsCorrect = false },
            new QuestionChoices
                { ID = 79, QuestionId = 20, Choice = "Its time complexity is not well-defined", IsCorrect = false },
            new QuestionChoices
            {
                ID = 80, QuestionId = 20,
                Choice = "Its quadratic time complexity makes it inefficient for large data structures",
                IsCorrect = true
            },
            new QuestionChoices { ID = 81, QuestionId = 21, Choice = "Quick Sort", IsCorrect = false },
            new QuestionChoices { ID = 82, QuestionId = 21, Choice = "Merge Sort", IsCorrect = false },
            new QuestionChoices { ID = 83, QuestionId = 21, Choice = "Heap Sort", IsCorrect = true },
            new QuestionChoices { ID = 84, QuestionId = 21, Choice = "Insertion Sort", IsCorrect = false },
            new QuestionChoices
            {
                ID = 85, QuestionId = 22, Choice = "Unsorted subsequences are combined into a single sorted sublist",
                IsCorrect = true
            },
            new QuestionChoices
            {
                ID = 86, QuestionId = 22, Choice = "Elements are divided into smaller sublists recursively",
                IsCorrect = false
            },
            new QuestionChoices
            {
                ID = 87, QuestionId = 22, Choice = "Adjacent elements are compared and swapped if necessary",
                IsCorrect = false
            },
            new QuestionChoices
            {
                ID = 88, QuestionId = 22, Choice = "The largest element is selected and appended to the sorted sublist",
                IsCorrect = false
            },
            new QuestionChoices { ID = 89, QuestionId = 23, Choice = "Divide and conquer", IsCorrect = true },
            new QuestionChoices { ID = 90, QuestionId = 23, Choice = "Greedy algorithm", IsCorrect = false },
            new QuestionChoices { ID = 91, QuestionId = 23, Choice = "Dynamic programming", IsCorrect = false },
            new QuestionChoices { ID = 92, QuestionId = 23, Choice = "Backtracking", IsCorrect = false },
            new QuestionChoices { ID = 93, QuestionId = 24, Choice = "Bubble Sort", IsCorrect = false },
            new QuestionChoices { ID = 94, QuestionId = 24, Choice = "Merge Sort", IsCorrect = false },
            new QuestionChoices { ID = 95, QuestionId = 24, Choice = "Insertion Sort", IsCorrect = true },
            new QuestionChoices { ID = 96, QuestionId = 24, Choice = "Quick Sort", IsCorrect = false },
            new QuestionChoices { ID = 97, QuestionId = 25, Choice = "To increase memory usage", IsCorrect = false },
            new QuestionChoices { ID = 98, QuestionId = 25, Choice = "To decrease time complexity", IsCorrect = false },
            new QuestionChoices
            {
                ID = 99, QuestionId = 25, Choice = "To avoid the limitations of comparing only adjacent elements",
                IsCorrect = true
            },
            new QuestionChoices
                { ID = 100, QuestionId = 25, Choice = "To increase the number of comparisons", IsCorrect = false },
            new QuestionChoices { ID = 101, QuestionId = 26, Choice = "Linear Search", IsCorrect = false },
            new QuestionChoices { ID = 102, QuestionId = 26, Choice = "Binary Search", IsCorrect = true },
            new QuestionChoices
            {
                ID = 103, QuestionId = 26, Choice = "Depth-First Search",
                IsCorrect = false
            },
            new QuestionChoices
                { ID = 104, QuestionId = 26, Choice = "Breadth-First Search", IsCorrect = false },
            new QuestionChoices { ID = 105, QuestionId = 27, Choice = "Array", IsCorrect = true },
            new QuestionChoices { ID = 106, QuestionId = 27, Choice = "Linked List", IsCorrect = false },
            new QuestionChoices
            {
                ID = 107, QuestionId = 27, Choice = "Hash Table",
                IsCorrect = false
            },
            new QuestionChoices
                { ID = 108, QuestionId = 27, Choice = "Stack", IsCorrect = false },
            new QuestionChoices { ID = 109, QuestionId = 28, Choice = "Linear Search", IsCorrect = false },
            new QuestionChoices { ID = 110, QuestionId = 28, Choice = "Binary Search", IsCorrect = true },
            new QuestionChoices
            {
                ID = 111, QuestionId = 28, Choice = "Interpolation Search",
                IsCorrect = false
            },
            new QuestionChoices
                { ID = 112, QuestionId = 28, Choice = "Depth-First Search", IsCorrect = false },
            new QuestionChoices
                { ID = 113, QuestionId = 29, Choice = "Binary search is easier to implement", IsCorrect = false },
            new QuestionChoices
            {
                ID = 114, QuestionId = 29, Choice = "Binary search works efficiently on unsorted arrays",
                IsCorrect = false
            },
            new QuestionChoices
            {
                ID = 115, QuestionId = 29, Choice = "Binary search has a lower time complexity",
                IsCorrect = true
            },
            new QuestionChoices
                { ID = 116, QuestionId = 29, Choice = "Binary search requires less memory.", IsCorrect = false },
            new QuestionChoices
            {
                ID = 117, QuestionId = 30, Choice = "When the array is sorted in descending order", IsCorrect = false
            },
            new QuestionChoices
                { ID = 118, QuestionId = 30, Choice = "When the array is extremely large", IsCorrect = false },
            new QuestionChoices
            {
                ID = 119, QuestionId = 30, Choice = "When the array is unsorted and has a small number of elements",
                IsCorrect = true
            },
            new QuestionChoices
                { ID = 120, QuestionId = 30, Choice = "When the array is sparse", IsCorrect = false },
            new QuestionChoices
            {
                ID = 121, QuestionId = 31, Choice = "True",
                IsCorrect = false
            },
            new QuestionChoices
                { ID = 122, QuestionId = 31, Choice = "False", IsCorrect = true },
            new QuestionChoices
            {
                ID = 123, QuestionId = 32, Choice = "True",
                IsCorrect = false
            },
            new QuestionChoices
                { ID = 124, QuestionId = 32, Choice = "False", IsCorrect = true }
        );
    }
}