from collections import Counter

def parse(path):
    f = open(path, 'r')
    fc = f.readlines()
    f.close()
    return fc


def getResponse(input):
    '''For part I'''
    ulist = []
    for i in input: 
        for s in i:
            if '\n' == s:
                continue
            if s not in ulist: 
                ulist.append(s)
    return len(ulist)

def getRespII(input): 
    '''For part II'''
    tot = 0
    onePerson = False
    group = []
    totalPeople = 0
    if (1 == len(input)):
        onePerson = True
    totalPeople = len(input)
    # I think this could be cleaned up with a better method of importing the file
    # I also think learning more Python methods might help reduce for loop usuage
    for i in input: 
        for s in i:
            if '\n' == s:
                continue
            group.append(s)
    if onePerson == True: 
        tot = len(group)
    else:
        amt = Counter(group)
        for k, v in amt.items():
            if v >= totalPeople: 
                tot += 1
    return tot


def start(input):
    totalQs = 0
    groupResp  = []
    for i in input: 
        if '\n' == i:
            #PART I totalQs += getResponse(groupResp)
            totalQs += getRespII(groupResp)
            groupResp = []
        else: 
            groupResp.append(i)
    return totalQs

print(start(parse("./input.txt")))
