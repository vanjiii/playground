#include "mango.h"

Mango* Mango::createMango(const char *FileName) {
    Mango *sprite = new Mango();
    if (sprite && sprite->initWithFile(FileName)) {
        sprite->autorelease();
        return sprite;

    }
    CC_SAFE_DELETE(sprite);
    return NULL;
}















