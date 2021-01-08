import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const Slug = () => {
  const [timer, setTimer] = useState(5);
  const [slugString, setSlugString] = useState("");
  const [flag, setFlag] = useState(true);

  const { slug } = useParams();

  useEffect(() => {
    const countDown = () => {
      if (timer === 0) {
        clearInterval(clock);
        if (slugString !== "") window.location = slugString;
      } else setTimer((pre) => pre - 1);
    };

    const getSlug = async () => {
      try {
        const response = await axios.patch(
          `http://localhost:5000/api/linkdata/view/${slug}`
        );
        console.log(response);
        setSlugString(response.data.fullLink);
      } catch (error) {
        alert(error.message.toString());
      }
    };
    if (flag) {
      getSlug();
      setFlag(false);
    }

    const clock = setInterval(() => {
      countDown();
    }, 1000);

    return () => {
      clearInterval(clock);
    };
  }, [timer, slugString, slug, flag]);
  return <>Your link will be ready in {timer} seconds</>;
};

export default Slug;
