import math

def parse(path):
    f = open(path, 'r')
    fc = f.readlines()
    f.close()
    return fc

def findSeatByMidpoint(input):
    '''
    Idea to find the seat by subtracting the difference and diving by to, this currently does not work.
    Need to make the UpperBoundRow cumulative, and subtract 1 to continue, similar idea for lowerbound
    Moved onto the binary approach instead below...
    '''
    upperBoundCol = 7
    upperBoundRow = 127
    lowerBoundCol = 0
    lowerBoundRow = 0 
    index = 0
    finalCol = 0
    finalRow = 0
    #mid point (+1 for low?) 
    print(input)
    for i in input: 
        if i == 'F': 
           upperBoundRow = math.floor((upperBoundRow - lowerBoundRow)/2)
            # Keep lower half
        if i == 'B':
             lowerBoundRow = math.floor((upperBoundRow - lowerBoundRow + 1)/2)
            # Keep upper half
        if i == 'R':
            upperBoundCol = math.floor((upperBoundCol - lowerBoundCol)/2)
        if i == 'L': 
            lowerBoundCol = math.floor((upperBoundCol - upperBoundCol + 1)/2)
        if index == 6:
            if i == 'F': 
                finalRow = upperBoundRow
            else: 
                finalRow = lowerBoundRow
        if index == 9:
            if i == 'R':
                finalCol = upperBoundCol
            else: 
                finalCol = lowerBoundCol
        index += 1
    return (finalCol, finalRow)

def dealWithBinary(input): 
    num = 0
    for b in input: 
        num = 2 * num + b
    return num

def findSeatWithBinary(input):
    binaryCol = []
    binaryRow = [] 
    for i in input: 
        if i == 'F': 
            binaryRow.append(0)
        if i == 'B':
            binaryRow.append(1)
        if i == 'R':
            binaryCol.append(1)
        if i == 'L': 
            binaryCol.append(0)
    #print("Row:", binaryRow)
    #print("Col: ", binaryCol)
    return (dealWithBinary(binaryCol), dealWithBinary(binaryRow))

def getSeatID(seatC, seatR):
    return seatR * 8 + seatC

def partOne():
    '''Find highest seat ID in the list'''
    highest = 0
    for i in parse("./input.txt"): 
       (seatC, seatR) = findSeatWithBinary(i)
       finalSeat = seatR * 8 + seatC
       if finalSeat > highest: 
           highest = finalSeat
    print("Highest seat #:", highest)

def partTwo(input):
    '''Find the missing seat id which is -1 or +1'''
    seats = []
    for i in input: 
        (seatC, seatR) = findSeatWithBinary(i)
        seats.append(getSeatID(seatC, seatR))
    seats.sort()
    nxt = 0
    for i in seats: 
        if(nxt != i): 
            print("Missing Seat: ", nxt)
        nxt = i + 1
    ##print(seats)
partOne()
partTwo(parse("./input.txt"))
