-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Окт 18 2016 г., 19:41
-- Версия сервера: 5.7.14
-- Версия PHP: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `karting`
--

-- --------------------------------------------------------

--
-- Структура таблицы `charity`
--

CREATE TABLE `charity` (
  `ID_Сharity` int(11) NOT NULL,
  `Charity_Name` varchar(100) NOT NULL,
  `Charity_Description` text,
  `Charity_Logo` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `charity`
--

INSERT INTO `charity` (`ID_Сharity`, `Charity_Name`, `Charity_Description`, `Charity_Logo`) VALUES
(1, 'Bill & Melinda Gates Foundation', 'Bill & Melinda Gates Foundation is the largest private foundation in the world, founded by Bill and Melinda Gates. It was launched in 2000 and is said to be the largest transparently operated private foundation in the world. The primary aims of the foundation are, globally, to enhance healthcare and reduce extreme poverty, and in America, to expand educational opportunities and access to information technology. The foundation, based in Seattle, Washington, is controlled by its three trustees: Bill Gates, Melinda Gates and Warren Buffett. Other principal officers include Co-Chair William H. Gates, Sr. and Chief Executive Officer Susan Desmond-Hellmann.', 'Gayts-Foundation.png'),
(2, 'GAVI', 'GAVI or Global Alliance for Vaccines and Immunization is a public-private global health partnership committed to increasing access to immunisation in poor countries', 'GAVI.png'),
(3, 'The Red Cross', 'Relief in times of crisis, care when it\'s needed most and commitment when others turn away. Red Cross is there for people in need, no matter who you are, no matter where you live.\r\n\r\nThe Red Cross Red Crescent Movement helps tens of millions of people around the world each year and we also care for local communities in our local country and further afield.\r\n\r\nWith millions of volunteers worldwide and thousands of members, volunteers and supporters, we can reach people and places like nobody else.', 'Red-Cross.png'),
(5, 'Oxfam International', 'Oxfam is an international confederation of 17 organizations working together with partners and local communities in more than 90 countries.', 'oxfam-international-logo.png'),
(7, 'Querstadtein Berlin', 'Querstadtein is the first project of Stadtsichten e.V., a registered non-profit association.', 'querstadtein-logo.png');

-- --------------------------------------------------------

--
-- Структура таблицы `country`
--

CREATE TABLE `country` (
  `ID_Country` char(3) NOT NULL,
  `Country_Name` varchar(50) NOT NULL,
  `Country_Flag` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `country`
--

INSERT INTO `country` (`ID_Country`, `Country_Name`, `Country_Flag`) VALUES
('AND', 'Andorra', 'flag_andorra.png'),
('ARG', 'Argentina', 'flag_argentina.png'),
('AUS', 'Australia', 'flag_australia.png'),
('AUT', 'Austria', 'flag_austria.png'),
('BEL', 'Belgium', 'flag_belgium.png'),
('BOT', 'Botswana', 'flag_botswana.png'),
('BRA', 'Brazil', 'flag_brazil.png'),
('BUL', 'Bulgaria', 'flag_bulgaria.png'),
('CAF', 'Central African Republic', 'flag_central_african_republic.png'),
('CAN', 'Canada', 'flag_canada.png'),
('CHI', 'Chile', 'flag_chile.png'),
('CHN', 'China', 'flag_china.png'),
('CIV', 'Ivory Coast', 'flag_ivory_coast.png'),
('CMR', 'Cameroon', 'flag_cameroon.png'),
('COL', 'Colombia', 'flag_colombia.png'),
('CRO', 'Croatia', 'flag_croatia.png'),
('CZE', 'Czech Republic', 'flag_czech_republic.png'),
('DEN', 'Denmark', 'flag_denmark.png'),
('DOM', 'Dominican Republic', 'flag_dominican_republic.png'),
('ECU', 'Ecuador', 'flag_ecuador.png'),
('EGY', 'Egypt', 'flag_egypt.png'),
('ESA', 'El Salvador', 'flag_el_salvador.png'),
('ESP', 'Spain', 'flag_spain.png'),
('EST', 'Estonia', 'flag_estonia.png'),
('FIN', 'Finland', 'flag_finland.png'),
('FRA', 'France', 'flag_france.png'),
('GBR', 'United Kingdom', 'flag_united_kingdom.png'),
('GBS', 'Guinea-Bissau', 'flag_guinea.png'),
('GEQ', 'Equatorial Guinea', 'flag_equatorial_guinea.png'),
('GER', 'Germany', 'flag_germany.png'),
('GRE', 'Greece', 'flag_greece.png'),
('GUA', 'Guatemala', 'flag_guatemala.png'),
('GUI', 'Guinea', 'flag_guinea-bissau.png'),
('HKG', 'Hong Kong', 'flag_hong_kong.png'),
('HON', 'Honduras', 'flag_honduras.png'),
('HUN', 'Hungary', 'flag_hungary.png'),
('INA', 'Indonesia', 'flag_indonesia.png'),
('IND', 'India', 'flag_india.png'),
('IRL', 'Ireland', 'flag_ireland.png'),
('ISR', 'Israel', 'flag_israel.png'),
('ITA', 'Italy', 'flag_italy.png'),
('JAM', 'Jamaica', 'flag_jamaica.png'),
('JOR', 'Jordan', 'flag_jordan.png'),
('JPN', 'Japan', 'flag_japan.png'),
('KEN', 'Kenya', 'flag_kenya.png'),
('KOR', 'South Korea', 'flag_south_korea.png'),
('KSA', 'Saudi Arabia', 'flag_saudi_arabia.png'),
('LAT', 'Latvia', 'flag_latvia.png'),
('LIE', 'Liechtenstein', 'flag_liechtenstein.png'),
('LTU', 'Lithuania', 'flag_lithuania.png'),
('LUX', 'Luxembourg', 'flag_luxembourg.png'),
('MAC', 'Macau', 'flag_macau.png'),
('MAD', 'Madagascar', 'flag_madagascar.png'),
('MAS', 'Malaysia', 'flag_malaysia.png'),
('MDA', 'Moldova ', 'flag_moldova.png'),
('MEX', 'Mexico ', 'flag_mexico.png'),
('MKD', 'Macedonia ', 'flag_macedonia.png'),
('MLI', 'Mali ', 'flag_mali.png '),
('MLT', 'Malta ', 'flag_malta.png '),
('MNE', 'Montenegro ', 'flag_montenegro.png '),
('MON', 'Monaco ', 'flag_monaco.png '),
('MRI', 'Mauritius ', 'flag_mauritius.png '),
('NCA', 'Nicaragua ', 'flag_nicaragua.png '),
('NED', 'Netherlands ', 'flag_netherlands.png '),
('NIG', 'Niger ', 'flag_niger.png '),
('NOR', 'Norway ', 'flag_norway.png '),
('NZL', 'New Zealand ', 'flag_new_zealand.png '),
('PAN', 'Panama ', 'flag_panama.png '),
('PAR', 'Paraguay ', 'flag_paraguay.png '),
('PER', 'Peru ', 'flag_peru.png '),
('PHI', 'Philippines ', 'flag_philippines.png '),
('POL', 'Poland ', 'flag_poland.png '),
('POR', 'Portugal ', 'flag_portugal.png '),
('PUR', 'Puerto Rico ', 'flag_puerto_rico.png '),
('QAT', 'Qatar ', 'flag_qatar.png '),
('ROU', 'Romania ', 'flag_romania.png '),
('RSA', 'South Africa ', 'flag_south_africa.png '),
('RUS', 'Russia ', 'flag_russia.png '),
('SEN', 'Senegal ', 'flag_senegal.png '),
('SIN', 'Singapore', 'flag_singapore.png '),
('SUI', 'Switzerland ', 'flag_switzerland.png '),
('SVK', 'Slovakia', 'flag_slovakia.png '),
('SWE', 'Sweden', 'flag_sweden.png '),
('THA', 'Thailand', 'flag_thailand.png '),
('TPE', 'Chinese Taipei ', 'flag_chinese_taipei.png '),
('TUR', 'Turkey ', 'flag_turkey.png '),
('UAE', 'United Arab Emirates ', 'flag_united_arab_emirates.png '),
('URU', 'Uruguay ', 'flag_uruguay.png '),
('USA', 'United States ', 'flag_usa.png '),
('VAT', 'Vatican ', 'flag_vatican.png '),
('VEN', 'Venezuela', 'flag_venezuela.png '),
('VIE', 'Vietnam', 'flag_vietnam.png ');

-- --------------------------------------------------------

--
-- Структура таблицы `event`
--

CREATE TABLE `event` (
  `ID_Event` int(11) NOT NULL,
  `Event_Name` varchar(50) NOT NULL,
  `ID_EventType` char(5) NOT NULL,
  `ID_Race` int(11) NOT NULL,
  `StartDateTime` datetime NOT NULL,
  `Cost` decimal(10,0) NOT NULL,
  `MaxParticipants` smallint(6) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `event`
--

INSERT INTO `event` (`ID_Event`, `Event_Name`, `ID_EventType`, `ID_Race`, `StartDateTime`, `Cost`, `MaxParticipants`) VALUES
(1, 'Cairo 2.5KM Race', '2.5KM', 4, '2015-03-17 00:00:00', '5000', 15),
(2, '\r\nGiza desert 6.5KM Race', '6.5KM', 4, '2015-03-25 00:00:00', '8000', 10),
(4, 'Red Send 4KM Race  ', '4KM', 4, '2015-03-10 00:00:00', '6500', 7),
(5, 'Rio 6.5KM Race', '6.5KM', 10, '2014-08-17 00:00:00', '2700', 10),
(7, 'Rio\'s Beach 4KM Race', '4KM', 10, '2014-08-10 00:00:00', '3500', 6),
(8, 'Carnaval 2.5KM Race', '2.5KM', 10, '2014-08-21 00:00:00', '12000', 15),
(9, 'Around of Paris 6.5KM Race', '6.5KM', 11, '2013-12-21 00:00:00', '4000', 4),
(10, 'Place Carrousel 2.5KM Race', '2.5KM', 11, '2013-12-15 00:00:00', '3000', 7),
(13, 'Munich 2.5KM Race', '2.5KM', 1, '2012-11-19 00:00:00', '4500', 8),
(15, 'BMW Factory 4KM Race', '4KM', 1, '2012-11-26 00:00:00', '7000', 10),
(19, 'Olympiaturm 6.5 KM', '6.5KM', 1, '2012-11-12 00:00:00', '3500', 4),
(20, 'Red Race 4KM', '4KM', 14, '2016-10-18 00:00:00', '6000', 8),
(21, 'Moscow ?ity 2.5KM Race', '2.5KM', 14, '2016-10-21 00:00:00', '3500', 6);

-- --------------------------------------------------------

--
-- Структура таблицы `event_type`
--

CREATE TABLE `event_type` (
  `ID_Event_type` char(5) NOT NULL,
  `Event_Type_Name` varchar(80) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `event_type`
--

INSERT INTO `event_type` (`ID_Event_type`, `Event_Type_Name`) VALUES
('2.5KM', '2.5km Race'),
('4KM', '4km Race'),
('6.5KM', '6.5km Race');

-- --------------------------------------------------------

--
-- Структура таблицы `gender`
--

CREATE TABLE `gender` (
  `ID_Gender` char(1) NOT NULL,
  `Gender_Name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `gender`
--

INSERT INTO `gender` (`ID_Gender`, `Gender_Name`) VALUES
('F', 'Female\r\n'),
('M', 'Male');

-- --------------------------------------------------------

--
-- Структура таблицы `race`
--

CREATE TABLE `race` (
  `ID_Race` int(11) NOT NULL,
  `Race_Name` varchar(80) NOT NULL,
  `Sity` varchar(50) NOT NULL,
  `ID_Country` char(3) NOT NULL,
  `Year_Held` smallint(6) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `race`
--

INSERT INTO `race` (`ID_Race`, `Race_Name`, `Sity`, `ID_Country`, `Year_Held`) VALUES
(1, 'Kart Skills 2012', 'Munich', 'GER', 2013),
(4, 'Kart Skills 2013', 'Cairo', 'EGY', 2016),
(10, 'Kart Skills 2014', 'Rio de Janeiro', 'BRA', 2015),
(11, 'Kars Skills 2015', 'Paris', 'FRA', 2014),
(14, 'Kart Skills 2016', 'Moscow', 'RUS', 2017);

-- --------------------------------------------------------

--
-- Структура таблицы `racer`
--

CREATE TABLE `racer` (
  `ID_Racer` int(11) NOT NULL,
  `First_Name` varchar(50) NOT NULL,
  `Last_Name` varchar(50) NOT NULL,
  `Gender` char(1) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `ID_Country` char(3) NOT NULL,
  `FileId` int
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `racer`
--

INSERT INTO `racer` (`ID_Racer`, `First_Name`, `Last_Name`, `Gender`, `DateOfBirth`, `ID_Country`) VALUES
(7, 'Liam', 'Jeferson', 'M', '1997-05-04', 'USA'),
(8, 'Anna', 'Ivanova', 'F', '1992-04-15', 'RUS'),
(9, 'Irakly', 'Vahsha', 'M', '1991-03-04', 'ISR'),
(10, 'Ernest', 'Huano', 'M', '1987-04-07', 'ESP'),
(11, 'Gamlet', 'Sertio', 'M', '1979-08-06', 'ITA'),
(12, 'Christian', 'Neel', 'M', '1984-12-21', 'USA'),
(13, 'Enrice', 'Mussoliny', 'M', '1989-04-05', 'ITA'),
(16, 'Lui', 'Andersen', 'M', '1978-07-05', 'USA'),
(19, 'Enrike', 'Atlandes', 'M', '1985-11-07', 'ARG'),
(20, 'Angela', 'Smith', 'F', '1975-12-31', 'FRA'),
(21, 'Lucius', 'Marko', 'M', '1987-08-16', 'ESP'),
(23, 'Andrey', 'Mishkevich', 'M', '1991-03-15', 'CZE'),
(26, 'Rita', 'Skitter', 'F', '1987-12-03', 'AUT'),
(27, 'Yamato', 'Zi', 'M', '1985-06-07', 'JPN'),
(28, 'Kuriko', 'Perno', 'F', '1987-08-03', 'ESP'),
(29, 'Viktor', 'Zulinc', 'M', '1983-12-01', 'CZE'),
(30, 'Elen', 'Huso', 'F', '1978-05-18', 'ARG'),
(33, 'Ahmad', 'Adkin', 'M', '1976-09-27', 'IRL'),
(34, 'Alphonso', 'Allison', 'M', '1983-09-12', 'SVK'),
(36, 'Alfreda', 'BURNHAM', 'F', '1980-05-21', 'MAD'),
(37, 'April', 'Bitsuile', 'F', '1995-09-27', 'CHI'),
(40, 'Aron', 'Brooks', 'M', '1988-09-06', 'MEX'),
(41, 'Angel', 'Candlish', 'F', '1975-02-15', 'CMR'),
(42, 'Austin', 'Crews', 'M', '1985-10-13', 'GRE'),
(43, 'Alisha', 'Conard', 'F', '1975-01-07', 'JAM'),
(44, 'Anika', 'Crockett', 'F', '1993-04-01', 'USA'),
(45, 'Brian', 'Lipke', 'M', '1981-09-24', 'PHI'),
(46, 'Bryan', 'Mccoy', 'M', '1979-05-05', 'USA'),
(48, 'Chiquita', 'Cline', 'F', '1990-10-16', 'HKG'),
(51, 'Cruz', 'Cook', 'F', '1985-10-17', 'KEN'),
(55, 'Charlie', 'Mcknight', 'F', '1984-01-20', 'TPE'),
(57, 'Gus', 'Titus', 'M', '1976-07-15', 'AUS'),
(58, 'Hugh', 'Bourbon', 'M', '1972-09-30', 'URU'),
(59, 'Robin', 'Carmona', 'M', '1981-03-18', 'SIN'),
(60, 'Simon', 'Steoud', 'M', '1974-12-29', 'KOR'),
(61, 'Zora', 'Chapman', 'F', '1980-07-03', 'GBR'),
(62, 'Waldo', 'Marby', 'M', '1986-03-03', 'MAC'),
(63, 'Willy', 'Spears', 'M', '1973-07-06', 'USA'),
(64, 'Vera', 'Prado', 'F', '1987-06-29', 'MEX'),
(66, 'Valeria', 'Sahagun', 'F', '1976-08-29', 'URU'),
(68, 'Raley', 'Steel', 'M', '1979-08-01', 'ESA'),
(69, 'Harry', 'Miller', 'M', '1988-12-11', 'USA'),
(70, 'Eva', 'Miller', 'F', '1991-03-25', 'USA'),
(71, 'Adam', 'Vergon', 'M', '1969-05-01', 'ARG'),
(72, 'Vahshee', 'Ahoul', 'M', '1975-06-04', 'IND'),
(73, 'Gretta', 'Veljor', 'F', '1975-08-27', 'GER'),
(75, 'Arman', 'Durs', 'M', '1984-02-14', 'IRL'),
(76, 'Uki', 'Cumoto', 'F', '1995-01-01', 'JPN'),
(78, 'Agnus', 'Wert', 'M', '1983-12-24', 'TPE'),
(79, 'Jerom', 'Votye', 'M', '1986-09-05', 'FRA');

-- --------------------------------------------------------

--
-- Структура таблицы `registration`
--

CREATE TABLE `registration` (
  `ID_Registration` int(11) NOT NULL,
  `ID_Racer` int(11) NOT NULL,
  `Registration_Date` date NOT NULL,
  `ID_Registration_Status` int(11) NOT NULL,
  `Cost` decimal(10,0) NOT NULL,
  `ID_Charity` int(11) NOT NULL,
  `SponsorshipTarget` decimal(10,0) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `registration`
--

INSERT INTO `registration` (`ID_Registration`, `ID_Racer`, `Registration_Date`, `ID_Registration_Status`, `Cost`, `ID_Charity`, `SponsorshipTarget`) VALUES
(1, 7, '2015-06-16', 1, '15', 1, '500'),
(4, 8, '2015-06-07', 2, '15', 3, '1500'),
(7, 9, '2015-09-17', 1, '15', 2, '700'),
(8, 10, '2015-07-05', 1, '15', 2, '863'),
(9, 11, '2015-12-25', 2, '15', 7, '439'),
(12, 12, '2015-01-08', 2, '15', 5, '752'),
(13, 13, '2015-05-09', 3, '15', 7, '600'),
(14, 16, '2015-10-05', 1, '15', 5, '800'),
(15, 19, '2015-02-10', 4, '15', 1, '420'),
(16, 20, '2015-01-19', 2, '15', 3, '750'),
(18, 21, '2015-02-12', 3, '15', 3, '500'),
(19, 23, '2015-06-08', 4, '15', 5, '350'),
(21, 26, '2015-12-05', 1, '15', 2, '400'),
(23, 27, '2015-05-07', 2, '15', 1, '250'),
(27, 28, '2015-06-18', 4, '15', 3, '1000'),
(28, 29, '2015-02-01', 3, '15', 7, '850'),
(29, 30, '2015-05-01', 1, '15', 2, '500'),
(30, 33, '2015-02-19', 2, '15', 2, '150'),
(31, 34, '2015-04-16', 4, '15', 1, '650'),
(32, 36, '2015-08-01', 1, '15', 5, '2500'),
(33, 37, '2015-08-27', 3, '15', 3, '280'),
(34, 40, '2016-01-01', 2, '15', 7, '1000'),
(35, 41, '2015-04-28', 1, '15', 1, '780'),
(36, 42, '2015-06-18', 1, '15', 3, '560'),
(37, 43, '2015-03-27', 4, '15', 5, '800'),
(39, 44, '2015-06-16', 3, '15', 2, '580'),
(40, 45, '2015-02-28', 3, '15', 1, '400'),
(41, 46, '2015-08-05', 1, '15', 2, '1800'),
(42, 48, '2015-12-23', 2, '15', 7, '4000'),
(43, 51, '2015-10-12', 3, '15', 2, '100'),
(44, 55, '2016-01-01', 2, '15', 3, '600'),
(45, 57, '2015-05-19', 1, '15', 5, '400'),
(46, 59, '2015-07-18', 2, '15', 7, '1350'),
(48, 60, '2015-09-11', 1, '15', 1, '2100'),
(49, 61, '2016-01-12', 1, '15', 2, '200'),
(50, 62, '2015-08-15', 4, '15', 5, '180'),
(51, 63, '2015-07-13', 3, '15', 3, '1200'),
(52, 64, '2015-05-27', 2, '15', 1, '520'),
(56, 66, '2015-11-15', 1, '15', 7, '100'),
(57, 68, '2016-02-01', 3, '15', 3, '280'),
(58, 69, '2015-07-18', 4, '15', 5, '2100'),
(59, 70, '2015-01-02', 1, '15', 2, '1100'),
(60, 71, '2015-06-17', 3, '15', 3, '400'),
(62, 72, '2015-01-04', 3, '15', 5, '600'),
(63, 73, '2015-08-13', 4, '15', 7, '320'),
(64, 75, '2015-03-29', 3, '15', 1, '840'),
(65, 76, '2015-07-14', 3, '15', 2, '1900'),
(66, 78, '2015-03-30', 1, '15', 3, '1500'),
(67, 79, '2015-08-16', 4, '15', 7, '2200'),
(68, 58, '2015-01-28', 4, '15', 1, '280');

-- --------------------------------------------------------

--
-- Структура таблицы `registration_status`
--

CREATE TABLE `registration_status` (
  `ID_Registration_Status` int(11) NOT NULL,
  `Statu_Name` varchar(80) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `registration_status`
--

INSERT INTO `registration_status` (`ID_Registration_Status`, `Statu_Name`) VALUES
(1, 'Registered'),
(2, '\nPayment Confirmed'),
(4, 'Race Attended');

-- --------------------------------------------------------

--
-- Структура таблицы `result`
--

CREATE TABLE `result` (
  `ID_Result` int(11) NOT NULL,
  `ID_Registration` int(11) NOT NULL,
  `ID_Event` int(11) NOT NULL,
  `BidNumber` smallint(6) NOT NULL,
  `RaceTime` time NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `result`
--

INSERT INTO `result` (`ID_Result`, `ID_Registration`, `ID_Event`, `BidNumber`, `RaceTime`) VALUES
(1, 1, 1, 1, '12:34:54'),
(2, 4, 1, 12, '00:10:15'),
(3, 7, 2, 23, '00:05:07'),
(5, 8, 4, 4, '00:03:17'),
(7, 9, 4, 25, '00:04:13'),
(8, 1, 2, 1, '00:05:14'),
(9, 28, 15, 31, '00:03:39'),
(10, 12, 19, 19, '00:06:01'),
(11, 13, 5, 34, '00:05:47'),
(14, 12, 2, 66, '00:05:47'),
(16, 13, 10, 9, '00:02:30'),
(17, 37, 21, 65, '00:02:30'),
(18, 40, 9, 32, '00:05:30'),
(19, 50, 4, 11, '00:04:00'),
(20, 7, 2, 23, '00:05:00'),
(21, 1, 4, 14, '00:02:30'),
(22, 68, 2, 15, '00:05:00'),
(23, 34, 7, 16, '00:03:00'),
(24, 41, 1, 17, '00:05:00'),
(25, 36, 21, 18, '00:02:30'),
(26, 37, 20, 19, '00:04:00'),
(27, 35, 15, 20, '00:04:00'),
(28, 48, 7, 21, '00:03:50'),
(29, 63, 4, 66, '00:03:47'),
(30, 60, 9, 54, '00:05:30'),
(31, 41, 4, 87, '00:03:55'),
(32, 32, 13, 98, '00:02:56'),
(33, 57, 20, 53, '00:03:57'),
(36, 64, 10, 63, '00:04:00'),
(37, 63, 19, 96, '00:05:15'),
(38, 39, 21, 42, '00:03:17'),
(39, 58, 7, 72, '00:02:42'),
(41, 44, 8, 56, '00:02:54'),
(43, 37, 2, 44, '00:06:11'),
(44, 29, 15, 87, '00:02:58'),
(45, 27, 21, 89, '00:01:56'),
(46, 8, 15, 49, '00:03:03'),
(47, 9, 20, 54, '00:03:21'),
(50, 30, 9, 38, '00:05:59'),
(52, 27, 19, 55, '00:03:07'),
(54, 41, 10, 1, '00:02:55'),
(55, 21, 2, 99, '00:06:56'),
(56, 39, 5, 456, '00:04:59'),
(57, 40, 1, 693, '00:02:14'),
(58, 29, 8, 12, '00:04:51'),
(59, 33, 21, 54, '00:02:13'),
(60, 7, 10, 66, '00:03:10'),
(61, 4, 13, 45, '00:04:01'),
(62, 19, 9, 71, '00:07:01');

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

CREATE TABLE `role` (
  `ID_Role` char(1) NOT NULL,
  `Role_Name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`ID_Role`, `Role_Name`) VALUES
('A', 'Administrator'),
('C', 'Coordinator'),
('R', 'Racer');

-- --------------------------------------------------------

--
-- Структура таблицы `sponsorship`
--

CREATE TABLE `sponsorship` (
  `ID_Sponsorship` int(11) NOT NULL,
  `SponsorName` varchar(150) NOT NULL,
  `Amount` decimal(10,0) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `sponsorship`
--

INSERT INTO `sponsorship` (`ID_Sponsorship`, `SponsorName`, `Amount`) VALUES
(1, 'Angel Jhons', '180'),
(2, 'Uri Kovrov', '25'),
(3, 'Asha Timbert', '150'),
(4, 'Artur Genby', '1000'),
(5, 'Gely Brick', '290'),
(6, 'Bondy Black', '236'),
(7, 'Ban Trick', '8000'),
(8, 'Oliver Greds', '5200'),
(9, 'Grindel Frool', '15000'),
(10, 'Emanuel Rick', '50'),
(11, 'Elena Tvordova', '150');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE `user` (
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `First_Name` varchar(30) NOT NULL,
  `Last_Name` varchar(30) NOT NULL,
  `ID_Role` char(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`Email`, `Password`, `First_Name`, `Last_Name`, `ID_Role`) VALUES
('L.Jeferson@gmail.com', '$1Qr3%9%r', 'Liam', 'Jeferson', 'R'),
('A.Ivanova@gmail.com', '%pO53f', 'Anna', 'Ivanova', 'R'),
('I.Vahsha@gmail.com', '34@7jpG', 'Irakly', 'Vahsha', 'R'),
('E.Huano@gmail.com', '72%V876^sE$', 'Ernest', 'Huano', 'R'),
('G.Sertio@gmail.com', '!44Qzvg2%!9', 'Gamlet', 'Sertio', 'R'),
('C.Neel@gmail.com', 'E@AJ#4c#5ad', 'Christian', 'Neel', 'R'),
('E.Mussoliny@gmail.com', '!H5N@@$1%@', 'Enrice', 'Mussoliny', 'R'),
('L.Andersen@gmail.com', '!pUzeL$^', 'Lui', 'Andersen', 'R'),
('E.Atlandes@gmail.com', '$@^3Ul^', 'Enrike', 'Atlandes', 'R'),
('A.Smith@gmail.com', 'UE$2T5!e$P', 'Angela', 'Smith', 'R'),
('L.Marko@gmail.com', 'NpRQo$!', 'Lucius', 'Marko', 'R'),
('A.Mishkevich@gmail.com', 'i1nO5$', 'Andrey', 'Mishkevich', 'R'),
('R.Skitter@gmail.com', 'GP6oAQ2', 'Rita', 'Skitter', 'R'),
('Y.Zi@gmail.com', 'o^zQ1!D', 'Yamato', 'Zi', 'R'),
('K.Perno@gmail.com', 'vXkN9%g', 'Kuriko', 'Perno', 'R'),
('V.Zulinc@gmail.com', 'Oc#LJH3I', 'Viktor', 'Zulinc', 'R'),
('E.Huso@gmail.com', '9uaC410#WL', 'Elen', 'Huso', 'R'),
('A.Adkin@gmail.com', 'B5ob@@2z', 'Ahmad', 'Adkin', 'R'),
('A.Allison@gmail.com', 'D10!61!', 'Alphonso', 'Allison', 'R'),
('A.BURNHAM@gmail.com', 'o0Xl^%@x%n9', 'Alfreda', 'BURNHAM', 'R'),
('A.Bitsuile@gmail.com', '^T%Vl%@s', 'April', 'Bitsuile', 'R'),
('A.Brooks@gmail.com', 'YE!Xx!4$', 'Aron', 'Brooks', 'R'),
('A.Candlish@gmail.com', 'Qf7Q#c$19@^', 'Angel', 'Candlish', 'R'),
('A.Crews@gmail.com', 'L0g$d@cj1R', 'Austin', 'Crews', 'R'),
('A.Conard@gmail.com', '^@ujJ1%W3^^', 'Alisha', 'Conard', 'R'),
('A.Crockett@gmail.com', 'F3ohCd!', 'Anika', 'Crockett', 'R'),
('B.Lipke@gmail.com', 'I7t515x', 'Brian', 'Lipke', 'R'),
('B.Mccoy@gmail.com', '@8$QR^3!c', 'Bryan', 'Mccoy', 'R'),
('C.Cline@gmail.com', 'T@M$YBa6', 'Chiquita', 'Cline', 'R'),
('C.Cook@gmail.com', 'SuU@!IC', 'Cruz', 'Cook', 'R'),
('C.Mcknight@gmail.com', '55n8mXY!sEB', 'Charlie', 'Mcknight', 'R'),
('G.Titus@gmail.com', 'Br8Xl!0', 'Gus', 'Titus', 'R'),
('H.Bourbon@gmail.com', '49uj!w', 'Hugh', 'Bourbon', 'R'),
('R.Carmona@gmail.com', '2836Xqt', 'Robin', 'Carmona', 'R'),
('S.Steoud@gmail.com', '%mXS3nK', 'Simon', 'Steoud', 'R'),
('Z.Chapman@gmail.com', 's9A64@69W1', 'Zora', 'Chapman', 'R'),
('W.Marby@gmail.com', '^k#Gi2^#n', 'Waldo', 'Marby', 'R'),
('W.Spears@gmail.com', '3%y1pv#H9', 'Willy', 'Spears', 'R'),
('V.Prado@gmail.com', 'u015D@EK', 'Vera', 'Prado', 'R'),
('V.Sahagun@gmail.com', 'iupTL%K5', 'Valeria', 'Sahagun', 'R'),
('R.Steel@gmail.com', 'IY7%#98B6', 'Raley', 'Steel', 'R'),
('H.Miller@gmail.com', 'yb%7%yq0', 'Harry', 'Miller', 'R'),
('E.Miller@gmail.com', '$D5^37V9G!%', 'Eva', 'Miller', 'R'),
('A.Vergon@gmail.com', 'Qq!vc@4o', 'Adam', 'Vergon', 'R'),
('V.Ahoul@gmail.com', '1gM^#5%%t7', 'Vahshee', 'Ahoul', 'R'),
('G.Veljor@gmail.com', 'fk94j!8^', 'Gretta', 'Veljor', 'R'),
('A.Durs@gmail.com', 'w2NL$vySH^K', 'Arman', 'Durs', 'R'),
('U.Cumoto@gmail.com', '69!bXu', 'Uki', 'Cumoto', 'R'),
('A.Wert@gmail.com', 'Isq%5IG!n', 'Agnus', 'Wert', 'R'),
('J.Votye@gmail.com', '^d$23wn7gt', 'Jerom', 'Votye', 'R');

-- --------------------------------------------------------

--
-- Структура таблицы `volunteer`
--

CREATE TABLE `volunteer` (
  `ID_Volunteer` char(3) NOT NULL,
  `First_Name` varchar(80) NOT NULL,
  `Last_Name` varchar(80) NOT NULL,
  `ID_Country` char(3) NOT NULL,
  `Gender_ID` char(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `сharity`
--

CREATE TABLE `сharity` (
  `сharityId` int(11) NOT NULL,
  `сharityName` varchar(100) NOT NULL,
  `сharityDescription` varchar(3000) NOT NULL,
  `Charity_Logo` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `charity`
--
ALTER TABLE `charity`
  ADD PRIMARY KEY (`ID_Сharity`);

--
-- Индексы таблицы `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`ID_Country`);

--
-- Индексы таблицы `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`ID_Event`),
  ADD KEY `ID_EventType` (`ID_EventType`,`ID_Race`),
  ADD KEY `FK_Event_Race` (`ID_Race`);

--
-- Индексы таблицы `event_type`
--
ALTER TABLE `event_type`
  ADD PRIMARY KEY (`ID_Event_type`);

--
-- Индексы таблицы `gender`
--
ALTER TABLE `gender`
  ADD PRIMARY KEY (`ID_Gender`);

--
-- Индексы таблицы `race`
--
ALTER TABLE `race`
  ADD PRIMARY KEY (`ID_Race`),
  ADD KEY `FK_Race_Country` (`ID_Country`);

--
-- Индексы таблицы `racer`
--
ALTER TABLE `racer`
  ADD PRIMARY KEY (`ID_Racer`),
  ADD KEY `ID_Country` (`ID_Country`),
  ADD KEY `FK_Racer_Gender` (`Gender`),
  ADD KEY `FileId` (`FileId`);

--
-- Индексы таблицы `registration`
--
ALTER TABLE `registration`
  ADD PRIMARY KEY (`ID_Registration`),
  ADD KEY `ID_Charity` (`ID_Charity`),
  ADD KEY `ID_Racer` (`ID_Racer`,`ID_Registration_Status`),
  ADD KEY `ID_Registration_Status` (`ID_Registration_Status`);

--
-- Индексы таблицы `registration_status`
--
ALTER TABLE `registration_status`
  ADD PRIMARY KEY (`ID_Registration_Status`);

--
-- Индексы таблицы `result`
--
ALTER TABLE `result`
  ADD PRIMARY KEY (`ID_Result`),
  ADD KEY `ID_Registration` (`ID_Registration`,`ID_Event`);

--
-- Индексы таблицы `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`ID_Role`);

--
-- Индексы таблицы `sponsorship`
--
ALTER TABLE `sponsorship`
  ADD PRIMARY KEY (`ID_Sponsorship`);

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD KEY `ID_Role` (`ID_Role`);

--
-- Индексы таблицы `volunteer`
--
ALTER TABLE `volunteer`
  ADD PRIMARY KEY (`ID_Volunteer`),
  ADD KEY `ID_Country` (`ID_Country`,`Gender_ID`),
  ADD KEY `FK_Volunteer_Gender` (`Gender_ID`);

--
-- Индексы таблицы `сharity`
--
ALTER TABLE `сharity`
  ADD PRIMARY KEY (`сharityId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `charity`
--
ALTER TABLE `charity`
  MODIFY `ID_Сharity` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT для таблицы `event`
--
ALTER TABLE `event`
  MODIFY `ID_Event` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT для таблицы `race`
--
ALTER TABLE `race`
  MODIFY `ID_Race` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT для таблицы `racer`
--
ALTER TABLE `racer`
  MODIFY `ID_Racer` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;
--
-- AUTO_INCREMENT для таблицы `registration`
--
ALTER TABLE `registration`
  MODIFY `ID_Registration` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;
--
-- AUTO_INCREMENT для таблицы `registration_status`
--
ALTER TABLE `registration_status`
  MODIFY `ID_Registration_Status` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT для таблицы `result`
--
ALTER TABLE `result`
  MODIFY `ID_Result` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;
--
-- AUTO_INCREMENT для таблицы `sponsorship`
--
ALTER TABLE `sponsorship`
  MODIFY `ID_Sponsorship` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `сharity`
--
ALTER TABLE `сharity`
  MODIFY `сharityId` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
