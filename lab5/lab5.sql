--2. Добавьте таблицы:
CREATE TABLE dvd 
(
	dvd_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	title	TEXT NOT NULL,
	production_year	TEXT NOT NULL
);

CREATE TABLE customer 
(
	customer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	TEXT NOT NULL,
	registration_date	TEXT NOT NULL
);

CREATE TABLE offer 
(
	offer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT NOT NULL
);

--3. Подготовьте SQL запросы для заполнения таблиц данными:
INSERT INTO dvd (title, production_year) 
VALUES 
	('Побег из Шоушенка', 1994),
	('Гарри Поттер и Дары Смерти: Часть I', 2010),	
	('Зеленая миля', 1999), 
	('Форрест Гамп', 1994), 
	('Как приручить дракона', 2010);	

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('Дарья', 'Киселева', '8810', '2010-11-07'), 
	('Сергей', 'Манахов', '8814', '2014-01-01'), 
	('Артем', 'Кудин', '8820', '2020-06-06'), 
	('Леонид', 'Мосягин', '8818', '2018-10-10'), 	
	('Екатерина', 'Ерофеева', '8807', '2007-05-04');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) 
VALUES 
	(5, 1, '2020-08-04', '2020-09-04'), 
	(2, 4, '2020-11-07', '2020-12-07'), 
	(3, 2, '2020-12-15', '2021-01-15'),
	(4, 1, '2020-02-08', '2020-03-08'),
	(5, 5, '2020-05-04', '2020-06-04');
	
-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, отсортированных в алфавитном порядке по названию DVD.
SELECT *
FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

-- 5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время находятся у клиентов.
SELECT title
FROM
	dvd
WHERE dvd_id IN
(
	SELECT dvd_id
	FROM 
		offer
	WHERE offer_date <= date('now') AND date('now') <= return_date
);

-- 6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD диски в текущем году. В результатах запроса необходимо также отразить какие диски брали клиенты.
SELECT 
	customer.customer_id, 
	customer.first_name, 
	customer.last_name, 
	dvd.dvd_id, 
	dvd.title,
	dvd.production_year
FROM customer
LEFT JOIN offer ON customer.customer_id = offer.customer_id
LEFT JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE 
	strftime('%Y', offer.offer_date) = '2020';