def board_to_string(board):
    result = ""
    count_row = 0    
    count_el = 0
    
    for row in board:
        count_row += 1
        result += "| "
        for element in row:
            count_el += 1
            result += element
            if count_el != 3:
                result += " | "
            else: 
                result += " |"
        if count_row != 3:    
            result += "\n"
            count_el = 0

    return result

