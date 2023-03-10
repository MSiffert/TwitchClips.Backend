window.registerInfiniteScroll = function (container, content, onScrollToEnd) {
    container.addEventListener("scroll", function () {
        if (container.scrollTop + container.offsetHeight >= content.offsetHeight) {
            onScrollToEnd.invokeMethodAsync('OnEndReached');
        }
    });
}
