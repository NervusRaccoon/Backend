--1.Напишите SQL запросы  для решения задач ниже. 
CREATE TABLE "PC" ( 
      "id" INTEGER PRIMARY KEY AUTOINCREMENT, 
      "cpu(MHz)" INTEGER NOT NULL, 
      "memory(Mb)" INTEGER NOT NULL, 
      "hdd(Gb)" INTEGER NOT NULL
); 

INSERT INTO PC ("cpu(MHz)", "memory(Mb)", "hdd(Gb)")
VALUES
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);
	
SELECT id, "cpu(MHz)", "memory(Mb)" FROM PC
WHERE "memory(Mb)" = 3000;
	
SELECT MIN("hdd(Gb)") AS hdd
FROM PC;

SELECT COUNT(*) AS Qty, "hdd(Gb)" FROM PC
WHERE "hdd(Gb)" = (SELECT MIN("hdd(Gb)") FROM PC)
	
--2.Есть таблица следующего вида:
CREATE TABLE "track_downloads" ( 
      "download_id" INTEGER PRIMARY KEY AUTOINCREMENT, 
      "track_id" INTEGER NOT NULL, 
      "user_id" INTEGER NOT NULL, 
      "download_time" TEXT NOT NULL DEFAULT 0
); 

INSERT INTO track_downloads (track_id, user_id, download_time)
VALUES
	(1, 2, "2010-11-19"),
	(2, 3, "2010-12-19"),
	(3, 4, "2010-10-19"),
	(1, 3, "2010-11-19"),
	(2, 3, "2010-11-19"),
	(3, 1, "2010-11-19");

SELECT DISTINCT download_count, COUNT(*) AS user_count 
FROM( 
    SELECT COUNT(*) AS download_count  
    FROM track_downloads WHERE download_time = "2010-11-19" 
    GROUP BY user_id
	)  
AS download_count 
GROUP BY download_count;

--3.Опишите разницу типов данных DATETIME и TIMESTAMP
/*Datetime хранит время, не зависящее от временной зоны, а время Timestamp при получении из базы отображается
с учетом часового пояса
Так же Datetime хранит время в виде целого числа вида YYYYMMDDHHMMSS, используя для этого 8 байтов,
в то время, как Timestamp Хранит 4-байтное целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года 
по усреднённому времени Гринвича*/

--4.Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name). 
--Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.
CREATE TABLE "students" ( 
      "student_id" INTEGER PRIMARY KEY AUTOINCREMENT, 
      "name" TEXT NOT NULL 
); 

CREATE TABLE "courses" ( 
      "courses_id" INTEGER PRIMARY KEY AUTOINCREMENT, 
      "name" TEXT NOT NULL
);

CREATE TABLE "students_in_courses" ( 
      "courses_id" INTEGER NOT NULL, 
      "student_id" INTEGER NOT NULL,
	  FOREIGN KEY(student_id) REFERENCES students(student_id),
	  FOREIGN KEY(courses_id) REFERENCES courses(courses_id)
);

INSERT INTO students(name)
VALUES
	('Сергей'),
	('Артем'),
	('Даша'),
	('Настя'),
	('Лена'),
	('Катя');
	
INSERT INTO courses(name)
VALUES
	('Моделирование'),
	('Программирование'),
	('Машинное обучение');
	
INSERT INTO students_in_courses(courses_id, student_id)
VALUES
	(1, 1),
	(2, 1),
	(1, 2),
	(3, 3),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6);
	
--отобразить количество курсов, на которые ходит более 5 студентов
SELECT courses.name, COUNT(students.student_id) as students
FROM students_in_courses
INNER JOIN courses ON (students_in_courses.courses_id = courses.courses_id)
INNER JOIN students ON (students_in_courses.student_id = students.student_id)
GROUP BY courses.courses_id
HAVING (COUNT(courses.courses_id) > 5);

--отобразить все курсы, на которые записан определенный студент.
SELECT courses.name, students.name
FROM students_in_courses
INNER JOIN courses ON (students_in_courses.courses_id = courses.courses_id)
INNER JOIN students ON (students_in_courses.student_id = students.student_id)
WHERE
	students.name = 'Катя';

/*5.Может ли значение в столбце(ах), на который наложено ограничение foreign key, равняться null? Привидите пример. 
Может, если на данный столбец не наложено ограничение not null, пример: 
при построении таблицы дерева файловой системы, где столбец foreign key - ссылка на эту же самую таблицу, 
на кортеж с информацией о родительской директории, тогда для корневой директории файловой системы в столбце 
родительской директории будет - null.*/

--6.Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
--Приведите пример таблиц с данными и запросы. 

--Можно переместить уникальные вхождения в копию таблицы и затем заменить таблицу. Пример:
CREATE TABLE "tea" (
      "id" INTEGER PRIMARY KEY AUTOINCREMENT,
      "name" TEXT NOT NULL
);

INSERT INTO tea (name)
VALUES
	('Ahmat'),
	('Ahmat'),
	('Tess'),
	('Ahmat'),
	('Reebok'),
	('ASD'),
	('Reebok');

CREATE TABLE "temp" AS SELECT * 
FROM tea 
WHERE 0;

INSERT INTO temp 
    SELECT id, name FROM
	(SELECT name, MIN(id) id FROM tea GROUP BY name) A
	ORDER BY id ASC;
	
DROP TABLE tea;

ALTER TABLE temp
  RENAME TO tea;
  
--7.Есть две таблицы
 CREATE TABLE "users" ( 
      "users_id" INTEGER PRIMARY KEY AUTOINCREMENT, 
      "name" TEXT NOT NULL 
); 

CREATE TABLE "orders" ( 
      "orders_id" INTEGER PRIMARY KEY AUTOINCREMENT, 
	  "users_id" INTEGER  NOT NULL, 
      "status" TEXT NOT NULL,
	  FOREIGN KEY(users_id) REFERENCES users(users_id)
);
 
INSERT INTO users (name)
VALUES
	('Катя'),
	('Маша'),
	('Саша'),
	('Сергей');

INSERT INTO orders (users_id, status)
VALUES
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(4, 1),
	(1, 0),
	(2, 0),
	(3, 1),
	(1, 0),
	(2, 1);

--Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
SELECT * 
FROM users 
WHERE 
	users_id NOT IN ( 
	SELECT users_id 
	FROM orders 
	WHERE 
		status <> 0)

--Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1
SELECT orders.users_id, users.name 
FROM orders 
INNER JOIN users ON users.users_id = orders.users_id 
WHERE orders.status = 1 GROUP BY orders.users_id 
HAVING COUNT(orders.status) > 5 
 

/*8.В чем различие между выражениями HAVING и WHERE?
WHERE сначала выбирает строки, а затем группирует их и вычисляет агрегатные функции, в то время как
HAVING отбирает строки групп после группировки и вычисления агрегатных функций*/