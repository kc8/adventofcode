def parse(path):
    f = open(path, 'r')
    fc = f.readlines()
    f.close()
    return fc

print(parse("./test_input.txt"))
