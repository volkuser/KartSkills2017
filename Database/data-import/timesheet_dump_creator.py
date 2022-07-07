import re
import random

import_data = open('kart-skills-2017-timesheet-import.txt', 'r')
output_dump = 'INSERT INTO `Timesheet` (`Staffid`, `StartDateTime`, ' \
              + '`EndDateTime`, `PayAmount`) VALUES'


def ch_format_datetime(input_datetime):
    y_match = re.search(r'.\d{4}', input_datetime)
    year = y_match[0].replace('.', '')
    m_match = re.search(r'.\d{2}.', input_datetime)
    month = m_match[0].replace('.', '')
    d_match = re.search(r'\d{2}.', input_datetime)
    day = d_match[0].replace('.', '')
    date = year + '-' + month + '-' + day
    time = re.sub(r'\d{2}.\d{2}.\d{4} ', '', input_datetime) + ':00'
    output_datetime = date + ' ' + time

    return output_datetime


first_line = True
for data_line in import_data.readlines():

    data_str = re.sub(r' {2,}', ' ', data_line.strip())
    if re.search(r'[a-zA-Z]', data_str) is None:
        if first_line:
            first_line = False
        else:
            output_dump += ','
        output_dump += '\n\t\t\t('
        match = re.search(r' \d{1,3} ', data_str)
        output_dump += match[0].replace(' ', '') + ', '
        match = re.search(r'\d{2}.\d{2}.\d{4} \d{2}:\d{2}', data_str)
        output_dump += '\'' + ch_format_datetime(match[0]) + '\', \''
        match = re.search(r':\d{2} \d{2}.\d{2}.\d{4} \d{2}:\d{2}', data_str)
        output_dump += ch_format_datetime(re.sub(r':\d{2} ', '', match[0])) + '\', ' \
            + str(round(random.uniform(500, 90000), 2)) + ')'

import_data.close()
output_dump += ';'

import_query = open('timesheet-import.sql', 'w')
import_query.write(output_dump)
import_query.close()
