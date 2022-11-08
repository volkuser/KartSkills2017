--
-- Структура таблицы `InventoryType`
--
CREATE TABLE `InventoryType`(
    `InventoryTypeId` INT NOT NULL,
    `TypeName` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
--
--
-- Структура таблицы `IncomingInventory`
--
CREATE TABLE `IncomingInventory`(
    `IncomingInventoryId` INT NOT NULL,
    -- `ID_Racer` INT NOT NULL,
    `Bracelet` INT DEFAULT 0,
    `Helmet` INT DEFAULT 0,
    `Equipment` INT DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `InventoryType`
--
INSERT INTO `InventoryType` (`InventoryTypeId`, `TypeName`) VALUES
(1, 'Тип A'),
(2, 'Тип B'),
(3, 'Тип C');

--
-- Индексы таблицы `InventoryType`
--
ALTER TABLE `InventoryType`
  ADD PRIMARY KEY (`InventoryTypeId`);
--
-- Индексы таблицы `InventoryType`
--
ALTER TABLE `IncomingInventory`
  ADD PRIMARY KEY (`IncomingInventoryId`);-- ,
  -- ADD KEY `ID_Racer` (`ID_Racer`);

--
-- AUTO_INCREMENT для таблицы `InventoryType`
--
ALTER TABLE `InventoryType`
  MODIFY `InventoryTypeId` INT NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `InventoryType`
--
ALTER TABLE `IncomingInventory`
  MODIFY `IncomingInventoryId` INT NOT NULL AUTO_INCREMENT;