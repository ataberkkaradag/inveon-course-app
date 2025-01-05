import { ButtonGroup, Button } from 'reactstrap';

function CategoryButtons({ categories, selectedCategory, setSelectedCategory }) {
  return (
    <ButtonGroup className="mb-4 category-buttons">
      <Button
        color={!selectedCategory ? 'primary' : 'secondary'}
        onClick={() => setSelectedCategory('')}
      >
        All
      </Button>
      {categories.map((category) => (
        <Button
          key={category.id}
          color={selectedCategory === category.id ? 'primary' : 'secondary'}
          onClick={() => setSelectedCategory(category.id)}
        >
          {category.name}
        </Button>
      ))}
    </ButtonGroup>
  );
}

export default CategoryButtons;