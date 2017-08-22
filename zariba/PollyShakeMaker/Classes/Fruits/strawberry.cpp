#include "strawberry.h"

Strawberry* Strawberry::createStrawberry(const char *FileName) {
    Strawberry *sprite = new Strawberry();
    if (sprite && sprite->initWithFile(FileName)) {
        sprite->autorelease();
        return sprite;

    }
    CC_SAFE_DELETE(sprite);
    return NULL;

}









