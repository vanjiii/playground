#include "pineapple.h"

Pineapple* Pineapple::createPineapple(const char *FileName) {
    Pineapple *sprite = new Pineapple();
    if (sprite && sprite->initWithFile(FileName)) {
        sprite->autorelease();
        return sprite;

    }
    CC_SAFE_DELETE(sprite);
    return sprite;

}
