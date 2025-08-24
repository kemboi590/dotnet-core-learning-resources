INSERT INTO Branches (BranchLocation, BranchPhoneNumber, BranchEmail)
VALUES 
('BBSR', '212-555-1234', 'BBSR@dotnettutorials.net'), 
('Delhi', '310-555-5678', 'Delhi@dotnettutorials.net'), 
('Mumbai', '312-555-9876', 'Mumbai@dotnettutorials.net'); 
GO


-- Insert data into Courses table
INSERT INTO Courses (Name, Description, Fees)
VALUES 
('Full Stack Dot Net', 'Comprehensive course covering front-end and back-end development using .NET technologies.', '6000'),
('Full Stack Java', 'End-to-end web development using Java technologies for front-end and back-end.', '5800'),
('Machine Learning', 'Introductory course to machine learning algorithms and data science.', '7000');
GO


-- Insert data into Subjects table
INSERT INTO Subjects (SubjectName, Description)
VALUES 
('ASP.NET Core Development', 'Developing web applications using ASP.NET Core framework.'),
('C# Programming', 'Deep dive into C# language features and best practices.'),
('JavaScript Frameworks', 'Working with modern JavaScript frameworks such as Angular and React.'),
('Java Programming', 'Comprehensive coverage of Java programming language.'),
('Spring Boot Development', 'Creating REST APIs using Spring Boot framework in Java.'),
('Machine Learning Algorithms', 'Introduction to various machine learning algorithms and techniques.'),
('Python for Data Science', 'Learn Python programming with a focus on data analysis and manipulation.'),
('Neural Networks and Deep Learning', 'Introduction to neural networks and deep learning techniques.');
GO

-- Insert data into Students table
INSERT INTO Students (FirstName, LastName, Gender, DateOfBirth, BranchId)
VALUES 
('John', 'Doe', 'Male', '2000-05-15', 1),
('Jane', 'Smith', 'Female', '2001-08-20', 2),
('Mark', 'Johnson', 'Male', '2002-03-10', 3),
('Emily', 'Clark', 'Female', '2000-11-05', 1),
('Sara', 'Taylor', 'Female', '2001-08-20', 2),
('James', 'Smith', 'Male', '2002-03-10', 3);
GO


-- Insert data into Teachers table
INSERT INTO Teachers (TeacherName, BranchId)
VALUES 
('Dr. Alice Johnson', 1),
('Dr. Bob Brown', 2),
('Dr. Carol White', 3),
('Dr. David Green', 1);
GO

-- Insert data into Addresses table
-- Student Addresses
INSERT INTO Addresses (Street, City, State, PostalCode, StudentId)
VALUES 
('123 Main St', 'New York', 'NY', '10001', 2),
('456 Oak St', 'Los Angeles', 'CA', '90001', 3),
('789 Pine St', 'Chicago', 'IL', '60601', 4),
('101 Maple St', 'New York', 'NY', '10001', 5);
GO

-- Teacher Addresses
INSERT INTO Addresses (Street, City, State, PostalCode, TeacherId)
VALUES 
('221B Baker St', 'New York', 'NY', '10001', 2),
('742 Evergreen Terrace', 'Los Angeles', 'CA', '90001', 3),
('1600 Pennsylvania Ave', 'Chicago', 'IL', '60601', 4),
('10 Downing St', 'New York', 'NY', '10001', 5);
GO


-- Insert data into CourseSubject table (Mapping Courses to Subjects)
-- Full Stack Dot Net
INSERT INTO CourseSubject (CoursesCourseId, SubjectsSubjectId)
VALUES 
(1, 1), -- Full Stack Dot Net -> ASP.NET Core Development
(1, 2), -- Full Stack Dot Net -> C# Programming
(1, 3); -- Full Stack Dot Net -> JavaScript Frameworks
GO
-- Full Stack Java
INSERT INTO CourseSubject (CoursesCourseId, SubjectsSubjectId)
VALUES 
(2, 4), -- Full Stack Java -> Java Programming
(2, 5), -- Full Stack Java -> Spring Boot Development
(2, 3); -- Full Stack Java -> JavaScript Frameworks
GO
-- Machine Learning
INSERT INTO CourseSubject (CoursesCourseId, SubjectsSubjectId)
VALUES 
(3, 6), -- Machine Learning -> Machine Learning Algorithms
(3, 7), -- Machine Learning -> Python for Data Science
(3, 8); -- Machine Learning -> Neural Networks and Deep Learning
GO


-- Insert data into CourseStudent table (Mapping Courses to Students)
INSERT INTO CourseStudent (CoursesCourseId, StudentsStudentId)
VALUES
(1, 2), -- John Doe -> Full Stack Dot Net
(2, 3), -- Jane Smith -> Full Stack Java
(3, 4), -- Mark Johnson -> Machine Learning
(2, 5), -- Emily Clark -> Full Stack Java
(1, 6), -- Sara Taylor -> Full Stack Dot Net
(3, 7); -- John Doe ->  Machine Learning
GO


INSERT INTO SubjectTeacher (SubjectsSubjectId, TeachersTeacherId)
VALUES
(1, 2), -- ASP.NET Core Development -> Dr. Alice Johnson
(2, 2), -- C# Programming -> Dr. Alice Johnson
(3, 5), -- JavaScript Frameworks -> Dr. David Green
(4, 3), -- Java Programming -> Dr. Bob Brown
(5, 4), -- Spring Boot Development -> Dr. Carol White
(6, 5), -- Machine Learning Algorithms -> Dr. David Green
(7, 3), -- Python for Data Science -> Dr. Bob Brown
(8, 4); -- Neural Networks and Deep Learning -> Dr. Carol White
GO