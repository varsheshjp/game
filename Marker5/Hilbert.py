def make_mapping(m):
    """
    Return a dictionary built up of a single mapping m rotated and flipped.
    The keys are 2 character strings where
    the first is one of [,],u,n and the second is either 'a'nticlockwise or
    'c'lockwise. The values are a list of integer, tuple pair which
    specify how to split up the 4 quadrants and which (shape, direction)
    pair to apply to it.
    The quadrants are
    ---------
    | 0 | 1 |
    ---------
    | 2 | 3 |
    ---------
    """
    quads = [0, 1, 3, 2]  # quadrants in clockwise order
    shapes = ['u', '[', 'n', ']']  # shapes rotated clockwise
    rots = ['a', 'c']  # possible rotations

    def next(item, list, pos=1):
        """
        Given a list and an item, reurns the item in the list
        pos places after the item.
        Wraps around the list at the boundaries
        """
        return list[(list.index(item) + pos) % len(list)]

    other_direction = lambda x: next(x, rots)
    next_quadrant = lambda x: next(x, quads)
    next_shape = lambda x: next(x, shapes)

    def rotate(key):
        rotated_value = [(next_quadrant(quad), next_shape(shape) + dirn)
                         for quad, (shape, dirn) in m[key]]
        shape, dirn = key
        return next_shape(shape) + dirn, rotated_value

    def flip(key):
        flipped_value = list(m[key])
        flipped_value.reverse()
        flipped_value = [(quad, shape+other_direction(dirn))
                         for quad, (shape, dirn) in flipped_value]
        shape, dirn = key
        return shape + other_direction(dirn), flipped_value

    key = list(m.keys())[0]
    while True:
        key, value = rotate(key)
        if key in m:
            break
        m[key] = value

    for key in list(m.keys()):
        newkey, value = flip(key)
        m[newkey] = value

    return m

hilbert_mapping = make_mapping(
    {'ua': [(0, ']c'), (2, 'ua'), (3, 'ua'), (1, '[c')]})

arrayOfPoints=[]
def apply_mapping(ar, mapping, pos):
    """
    split the 2d array ar into 4 quadrants and call
    apply_mapping recursively for each member of map[pos]
    If ar is 1x1, yield ar
    """
    try:
        y, x = ar.shape[:2]
    except ValueError:
        print(ar, ar.shape)
    if y <= 1 and x <= 1:
        yield ar[0, 0, ...]
    else:
        # quad indices here are:
        #  0  1
        #  2  3
        # (nb unlike hilbert_v1!)
        first_half = slice(None,int( x / 2))
        secnd_half = slice(int( x / 2), None)
        quads = [ar[first_half, first_half, ...],
                 ar[first_half, secnd_half, ...],
                 ar[secnd_half, first_half, ...],
                 ar[secnd_half, secnd_half, ...]]
        for quadrant, newpos in mapping[pos]:
            for x in apply_mapping(quads[quadrant], mapping, newpos):
                yield x


def hilbert(ar):
    for x in apply_mapping(ar, hilbert_mapping, 'ua'):
        yield x