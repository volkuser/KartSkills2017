-- --------------------------------------------------------

--
-- Структура таблицы `Position`
--
CREATE TABLE `Position` (
  `Positionid` integer NOT NULL,
  `PositionName` varchar(100) NOT NULL,
  `PositionDescription` varchar(200),
  `PayPeriod` varchar(10) NOT NULL,
  `PayRate` decimal(10,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `Staff`
--
CREATE TABLE `Staff` (
    `Staffid` integer NOT NULL,
    `First_name` varchar(80) NOT NULL,
    `LastName` varchar(80) NOT NULL,
    `DateOfBirth` datetime NOT NULL,
    `Gender` varchar(10) NOT NULL,
    `Positionid` smallint NOT NULL,
    `Email` varchar(100) NOT NULL,
    `Comments` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `Timesheet`
--
CREATE TABLE ` Timesheet`(
    `Timesheetid` integer NOT NULL,
    `Staffid` integer NOT NULL,
    `StartDateTime` datetime,
    `EndDateTime` datetime,
    `PayAmount` decimal(10,2)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Индексы таблицы `Position`
--

ALTER TABLE `Position`
  ADD PRIMARY KEY (`Positionid`);

--
-- Индексы таблицы `Staff`
--

ALTER TABLE `Staff`
  ADD PRIMARY KEY (`Staffid`),
  ADD KEY `Positionid` (`Positionid`);

--
-- Индексы таблицы `Timesheet`
--

ALTER TABLE `Timesheet`
  ADD PRIMARY KEY (`Timesheetid`),
  ADD KEY `Staffid` (`Staffid`);

-- --------------------------------------------------------

--
-- AUTO_INCREMENT для таблицы `Position`
--
ALTER TABLE `Position`
  MODIFY `PositionId` integer NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `Staff`
--
ALTER TABLE `Staff`
  MODIFY `Staffid` integer NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `Timesheet`
--
ALTER TABLE `Timesheet`
  MODIFY `Timesheetid` integer NOT NULL AUTO_INCREMENT;