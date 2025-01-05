import React from 'react';
import { Carousel, CarouselItem, CarouselControl, CarouselIndicators, CarouselCaption } from 'reactstrap';

function FeaturedCoursesCarousel({ courses }) {
  const items = courses.slice(0, 3).map((course, index) => ({
    src: 'https://picsum.photos/1200/400',
    altText: course.title,
    caption: course.description,
    key: index,
  }));

  const [activeIndex, setActiveIndex] = React.useState(0);
  const [animating, setAnimating] = React.useState(false);

  const next = () => {
    if (animating) return;
    const nextIndex = activeIndex === items.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(nextIndex);
  };

  const previous = () => {
    if (animating) return;
    const nextIndex = activeIndex === 0 ? items.length - 1 : activeIndex - 1;
    setActiveIndex(nextIndex);
  };

  const slides = items.map((item) => (
    <CarouselItem
      key={item.key}
      onExiting={() => setAnimating(true)}
      onExited={() => setAnimating(false)}
    >
      <img style={{width:'100%'}} src={item.src} alt={item.altText} />
      <CarouselCaption captionText={item.caption} captionHeader={item.altText} />
    </CarouselItem>
  ));

  return (
    <div className="carousel-container">
    <Carousel activeIndex={activeIndex} next={next} previous={previous}>
      <CarouselIndicators items={items} activeIndex={activeIndex} onClickHandler={(newIndex) => setActiveIndex(newIndex)} />
      {slides}
      <CarouselControl direction="prev" directionText="Previous" onClickHandler={previous} />
      <CarouselControl direction="next" directionText="Next" onClickHandler={next} />
    </Carousel>
    </div>
  );
}


export default FeaturedCoursesCarousel;