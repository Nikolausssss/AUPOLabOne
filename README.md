# LabOne
## Назначение программы.

Программа предназначена для выполнения CRUD (Create Read Update Delete) операций над данными в базе данных школы.


## Указания по запуску программы.

- Для запуска на Windows
	1. Для запуска необходим SDK .NET 7.0, если у вас он не установлен, то скачать можно тут https://dotnet.microsoft.com/en-us/download/dotnet/7.0
	2. Скачать релиз с GitHub 
	3. Разархивировать в папку
	4. Запустить файл LabOne.exe из cmd.
	5. Вписать в браузер значение в строке "Now listening on:" (http://localhost:"порт")

- Для запуска в Docker (docker-compose)
	1. Склонировать код с репозитория GitHub
	2. Запустить в cmd из папки с проектом команду: docker-compose build
	3. После чего запустить команду: docker-compose up
	4. Контейнер запустится на свободном порту, чтобы его узнать необходимо ввести команду: docker ps
	5. Вписать в браузер: http://localhost:"порт переадресации на 443 порт в докере"/

- Для запуска в Docker (dockerfile)
	1. Склонировать код с репозитория GitHub
	2. Запустить в cmd из папки с проектом команду: docker build -t "имя образа"
	3. После чего запустить команду: docker run -it -p 5000:80 "имя образа"
	4. Контейнер запустится на порту  5000
	5. Вписать в браузер: http://localhost:5000

## Описание файлов и сущностей проекта.

- Сущности
	Учебный год - Year
	Уровень образования - Level - начальная, средняя или старшая школа
	Параллель - Parallel - параллель обучения, например, 1 класс, 2 класс и т.д.
	Учитель - Teacher
	Класс - Course - учебный класс, например, 1а
	Ученик - Scholar

- Data
	Папка Data содержит файлы с описанием классов представлений сущности БД, а также ApplicationContext, позволяющий существлять взаимодействие с базой данных.

- Pages
	Папка Pages содержит файлы с описанием HTML страниц (.cshtml), отображаемых пользователю при запросе, а также файлы с описанием обработки запросов пользователей с этих страниц (.cshtml.cs). Страницы называются именем осуществляемого действия над БД. Так, например, файл Courses/Create.cshtml осуществляет отображение страницы для создания нового экземпляра сущности класс (Course), а файл Course/Create.cshtml.cs отвечает за обработку запросов (GET, POST) от пользователя с этой страницы.


## Список используемых подпрограмм.

Программа создана на основе свободно распространяемого фреймворка ASP.Net на платформе .Net 7.0


## Требуемый объем памяти.

Не менее 100 Мб оперативной памяти и не менее 200 Мб постоянной


## Сведения об авторе.

Смирнов Николай Александрович. КМБ-1-2018.


## Дата написания программы.
02.03.2023