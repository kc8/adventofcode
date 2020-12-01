
#Day 1 Dec 1, 2020 https://adventofcode.com/2020/day/1

def parse(path):
    data = []
    bad_chars = [" ", '\n']
    f = open(path, 'r')
    for l in f.readlines():
        l.strip()
        if( l not in bad_chars):
            data.append(l)
    f.close()
    return data

def find_sum(a, b, c, sum = 2020): 
    if(a + b + c == sum): 
        return True
    else: 
        return False

item_input = parse("./inputs.txt")

for a in item_input:
#    print(a)
    for b in item_input:
        for c in item_input:
            if(find_sum(int(a), int(b), int(c))): 
                print("Found the sum")
                print(int(a) * int(b) * int(c))

