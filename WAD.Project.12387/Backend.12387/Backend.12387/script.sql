declare @DataDirectory varchar(2000) = 'APPDATA FULL PATH' -- Add AppData full path here 

declare @sql nvarchar(max) = 'CREATE DATABASE FootballDb          
        ON PRIMARY (
           NAME=db_data,
           FILENAME = ''{DataDirectory}\FootballDb.mdf''
        )
        LOG ON (
            NAME=db_log,
            FILENAME = ''{DataDirectory}\FootballDb.ldf''
        )'
set @sql = replace(@sql, '{DataDirectory}', @DataDirectory)
exec (@sql)
GO
use FootballDb 
GO

GO
set language english;
GO
CREATE TABLE [dbo].[Leagues] (
    [LeagueId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Country] NVARCHAR(200) NOT NULL
);

GO
CREATE TABLE [dbo].[Clubs] (
  [ClubId] INT NOT NULL IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  [CoachName] NVARCHAR(200) NOT NULL,
  [StadiumName] NVARCHAR(200) NOT NULL,
  [ImageLink] NVARCHAR(1000) NOT NULL,
  [FoundedYear] DateTime NOT NULL,
  [LeagueId] INT NOT NULL,
);

GO
CREATE TABLE [dbo].[Players] (
    [PlayerId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Age] INT NOT NULL,
    [Position] NVARCHAR(200) NOT NULL,
    [ImageLink] NVARCHAR(200) NOT NULL,
    [ClubId] INT NOT NULL
);

GO
CREATE TABLE [dbo].[LeagueTables](
    [LeagueTableId] INT NOT NULL IDENTITY,
    [ClubId] INT NOT NULL,
    [Draw] INT NOT NULL,
    [Won] INT NOT NULL,
    [Lost] INT NOT NULL,
    [Position] INT NOT NULL,
    [GoalsAgainst] INT NOT NULL,
    [GoalsFor] INT NOT NULL,
    [PlayedGames] INT NOT NULL,
    [Points] INT NOT NULL,
    [LeagueId] INT NOT NULL,
);

GO
INSERT INTO [dbo].[Leagues]
([Name], [Country])
VALUES(
    'Premier League', 'England'),
    ('La Liga', 'Spain'),
    ('Bundesliga', 'Germany'),
    ('Serie A', 'Italy'),
    ('Ligue 1', 'France');

GO
INSERT INTO [dbo].[Clubs]
([Name], [CoachName], [StadiumName], [FoundedYear], [ImageLink], [LeagueId])
VALUES (
    'Manchester United', 'Eric Ten-Haag', 'Old Traford', GETDATE(), 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrd1G_ZYUq8vZ8OqIZNSKCvgrDUygH47bf9g&usqp=CAU', 1),
    ('Arsenal', 'Mikel Arteta', 'Empire Stadium', GETDATE(), 'https://wallpapercave.com/wp/wp7422182.jpg', 1 ),
    ('Manchester City', 'Pep Guardiola', 'Etihad Stadium', GETDATE(), 'https://vectorseek.com/wp-content/uploads/2021/12/Manchester-City-Logo-Vector.jpg', 1),
    ('Newcastle United', 'Eddie Howe', 'St. James Park', GETDATE(), 'https://reciteme.com/wp-content/uploads/2022/07/Newcastle-FC-Testimonial-1024x1024.png', 1 ),
    ('Tottenham Hotspur', 'Cristian Stellini', 'Tottenham Hotspur Stadium', GETDATE(), 'https://yt3.googleusercontent.com/LZq29V-hPkycwJDyK5uCnwRy90f-K4hnsn3JVH9V0Y9jbVTMxyBDY6hP6fBhC6xpzI9Emr4W=s900-c-k-c0x00ffffff-no-rj', 1 ),
    ('Brighton', 'Roberto De Zerbi', 'American Express Community', GETDATE(), 'https://w0.peakpx.com/wallpaper/306/538/HD-wallpaper-brighton-hove-albion-football-club-premier-league-brighton-hove-united-kingdom-england-emblem-logo-english-football-club.jpg', 1),
    ('Aston Villa', 'Unai Emery', 'Villa Park', GETDATE(), 'https://yt3.googleusercontent.com/9TiGUllhklG_3xtvMl4w8s7Lf_LRX30eENzoRpOWSPJR3YbCH7yAZKIjxWuHC9RQ84vnuDgSSQ=s900-c-k-c0x00ffffff-no-rj', 1),
    ('Liverpool', 'Jurgen Klopp', 'Anfield Stadium', GETDATE(), 'https://logowik.com/content/uploads/images/526_liverpoolfc.jpg', 1),
    ('Brentford', 'THomas Frank', 'Gtech Community Stadium', GETDATE(), 'https://centaur-wp.s3.eu-central-1.amazonaws.com/designweek/prod/content/uploads/2016/11/11152232/Unknown4-882x500.jpeg', 1),
    ('Filham', 'Marco Silva', 'Craven Cottage', GETDATE(), 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTW4xnVtorAZDpwjvSjSh23ZhDpLvFJWDHkOg&usqp=CAU', 1),
    ('Barcelona', 'Xavi', 'Camp Nou', GETDATE(), 'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiXsgclNmJTqKsMKkgLOw-HM8VITwQ9tfkdMYnD8WiF1KfbvaPNg889GUmC20BmjHH6ke3jiONRp13GSq6vFw4Mg3m9T1Cz7-zAxXo8aK7IEVY7hnbJnLDYqN4Tkym-HqalgD2PPnV6Gogukby1L9Lw0hGYnkdVxL0OpCNDbYpBs9OEnOfFr1JYhIi-/s1600/barcelona%20to%20change%20logo%20%282%29.png', 2),
    ('Real Madrid', 'Carlo Ancelotti', 'Santiago Bernabeu', GETDATE(), 'https://seuladogeek.com.br/wp-content/uploads/2022/02/Real-Madrid-FC-Logo-downlaod-Vector-and-PNG.png', 2),
    ('Atletico Madrid', 'Diego Simeone', 'Civitas Metropolitan', GETDATE(), 'https://logowik.com/content/uploads/images/464_atletico_madrid.jpg', 2),
    ('Bayern', 'Franz John', 'Allianz Arena', GETDATE(), 'https://logowik.com/content/uploads/images/857_fcbayernmunich.jpg', 3),
    ('Bortmund', 'Edin Terzic', 'Signal Iduna Park', GETDATE(), 'https://logowik.com/content/uploads/images/270_borussia_dortmund.jpg', 3),
    ('Napoli', 'Lucaino Spaletti', 'Diego Armando Maradona Stadium', GETDATE(), 'https://1000logos.net/wp-content/uploads/2018/07/Napoli-logo.jpg', 4),
    ('Paris Saint-Germain', 'Christopher Galtier', 'Le Parc des Princes', GETDATE(), 'https://vetores.org/wp-content/uploads/psg-paris-saint-germain.png', 5);
   
GO 
INSERT INTO [dbo].[Players]
([Name], [Age], [Position], [ImageLink], [ClubId])
VALUES (
    'Marcus Rashford', 25, 'Left Forward', 'https://library.sportingnews.com/2023-01/GettyImages-1454058933_1.jpg', 1),
    ('Casemiro', 31, 'Midfielder', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blt1926021b5334f5e1/63c24f63a9748f582372fe06/Casemiro.jpg', 1),
    ('Antony', 23, 'Forward', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/bltce11832f34bdf210/635edb357abc121050615584/GettyImages-1437111935.jpg', 1),
    ('Wout Weghorst', 31, 'Forward', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blt72c112f3cb20646f/642006f380ec436c423da291/GettyImages-1248396790.jpg', 1),
    ('Alejandro Garnacho', 22, 'Forward', 'https://cdn.images.express.co.uk/img/dynamic/67/590x/Man-Utd-news-Alejandro-Garnacho-contract-1736988.jpg?r=1676935752040', 1),
    ('Marcel Sabitzer', 28, 'Midfielder', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blt8b1c4193f6b03c15/63ea4b8d09ef325af8ec16d6/GOAL_-_Blank_WEB_-_Facebook_(82).png', 1),
    ('Jadon Sancho', 23, 'Forward', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/bltddd15d5cc40d99e8/63b7dfb4ea947158ef1ffc93/GettyImages-1432199808.jpg', 1),
    ('Bruno Fernandes', 28, 'Midfielder', 'https://media.cnn.com/api/v1/images/stellar/prod/230401052749-01-bruno-fernandes-man-u-031623-file.jpg?c=original', 1),
    ('Lisandro Martinez', 24, 'Midfielder', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blt1926021b5334f5e1/63c24f63a9748f582372fe06/Casemiro.jpg', 1),
    ('David De Gea', 32, 'Goalkeeper', 'https://i2-prod.manchestereveningnews.co.uk/incoming/article26589213.ece/ALTERNATES/s615/0_GettyImages-1248914454.jpg', 1),
    ('Christain Eriksen', 31, 'Midfielder', 'https://weallfollowunited.com/wp-content/uploads/2022/11/fbl-wc-2022-match06-den-tun-758x505.jpg', 1),
    ('Raphael Varane', 25, 'Defender', 'https://m.media-amazon.com/images/M/MV5BMTBjYjU3MmEtYTJjMi00YWQ5LWE5YmUtMDNlMTE3ZjI5MjRjXkEyXkFqcGdeQXVyMjUyNDk2ODc@._V1_.jpg', 1),
    ('Diogo Dalot', 24, 'Midfielder', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blte3c475fed327c227/6322101dbbe66a49b2d4b54d/Untitled_design_(6).jpg', 1),
    ('Jude Bellingham', 20, 'Midfielder', 'https://icdn.football-espana.net/wp-content/uploads/2023/03/BELLINGHAM2.jpeg', 15),
    ('Marco Reus', 31, 'Forward', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/bltc940aca06313defc/60db774a5775160f9f21a55d/e161556eeef1e3e85f577cda2a4b566faea3d834.jpg', 15),
    ('Leandro Trossard', 28, 'Forward', 'https://e0.365dm.com/23/02/2048x1152/skysports-arsenal-leandro-trossard_6070164.jpg', 2),
    ('Martin Odegaard', 24, 'Midfielder', 'https://assets.goal.com/v3/assets/bltcc7a7ffd2fbf71f5/blte466797143306dd1/63ce5f5e5a86df0d42937d70/GettyImages-1458540278.jpg', 2);


GO
INSERT INTO [dbo].[LeagueTables]
([ClubId], [Draw], [Won], [Lost], [Position], [GoalsAgainst], [GoalsFor], [PlayedGames], [Points], [LeagueId])
VALUES (
    1, 5, 37, 7, 4, 37, 42, 28, 53, 1),
    (2, 3, 23, 3, 1, 27, 70, 29, 72, 1),
    (3, 4, 20, 4, 2, 26, 70, 28, 64, 1),
    (4, 11, 14, 3, 3, 20, 46, 28, 53, 1),
    (5, 5, 15, 9, 5, 41, 53, 29, 50, 1),
    (6, 7, 13, 7, 6, 34, 51, 27, 46, 1),
    (7, 5, 13, 11, 7, 40, 39, 29, 44, 1),
    (8, 7, 12, 9, 8, 33, 42, 28, 43, 1),
    (9, 13, 10, 6, 9, 38, 46, 28, 43, 1),
    (10, 6, 11, 11, 10, 39, 39, 28, 39, 1),
    (11, 2, 23, 2, 1, 9, 53, 27, 71, 2),
    (12, 5, 18, 4, 2, 21, 57, 27, 59, 2),
    (13, 6, 16, 5, 3, 19, 42, 27, 54, 2),
    (14, 7, 16, 3, 1, 29, 76, 26, 55, 3),
    (15, 2, 17, 7, 2, 35, 57, 26, 53, 3),
    (16, 2, 23, 3, 1, 20, 64, 28, 71, 4),
    (17, 3, 21, 5, 1, 29, 68, 29, 66, 5);