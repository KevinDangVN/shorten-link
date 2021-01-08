import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const Slug = () => {
  const [timer, setTimer] = useState(5);
  const [slugString, setSlugString] = useState("");

  const { slug } = useParams();

  useEffect(() => {
    const countDown = () => {
      if (timer === 0) {
        clearInterval(clock);
        if (slugString !== "") window.location = slugString;
      } else setTimer((pre) => pre - 1);
    };

    const getSlug = async () => {
      const response = await axios.patch(
        `http://localhost:5000/api/linkdata/view/${slug}`
      );
      console.log(response);
      setSlugString(response.data.fullLink);
    };
    if (slugString === "") getSlug();

    const clock = setInterval(() => {
      countDown();
    }, 1000);

    return () => {
      clearInterval(clock);
    };
  }, [timer, slugString, slug]);
  return <>Your link will be ready in {timer} seconds</>;
};

export default Slug;
