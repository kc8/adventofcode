#Day 3 Dec 3, 2020 https://adventofcode.com/2020/day/3

#Notes for helping to solve: 
# The entire pattern can repeat. 
# Part 1 does not specify repeat, but does not matter because you would reach the end before repeating

def parse(path):
    data = []
    f = open(path, 'r')
    for l in f.readlines():
        data.append(l)
    f.close()
    return data

def DetermineTreesInPath(trail):
    '''
        Part 1
        This tripped me up a little when I first started, I did not consider any repeation in the pattern so my answer was 5. 
        Then It looks like len() in Python was returning +1 which may have something to do with the formatmting in the input?
    '''
    StringPosCounter = 0 
    TreeCounter = 0
    try:  
        for t in trail:
            if t[StringPosCounter] == '#': 
                TreeCounter += 1
            StringPosCounter += 3 
            StringPosCounter %= len(trail[0])-1
    except Exception as e:
        print("Exception was Caught ", e)
    return TreeCounter

def DetermineTreesPartTwo(trail, right, down):
    '''
        This part is incomplete and is incorrect
    '''

    StringPosCounter = 0 
    TreeCounter = 0
    i = 0 
    try:  
        for t in trail:
            if (down > 1 and i % down == 0): 
                pass
            i += 1
            if t[StringPosCounter] == '#': 
                TreeCounter += 1
            StringPosCounter += right; 
            StringPosCounter %= len(trail[0])-1
    except Exception as e:
        print("Exception was Caught ", e)
    return TreeCounter

trail = parse("./input.txt") 
print("Total Part 1:", DetermineTreesInPath(trail))

print("Total Part two: ", DetermineTreesPartTwo(trail, 1, 1) * DetermineTreesPartTwo(trail, 3, 1) * DetermineTreesPartTwo(trail, 5, 1) * DetermineTreesPartTwo(trail, 7, 1) * DetermineTreesPartTwo(trail, 1, 2));
