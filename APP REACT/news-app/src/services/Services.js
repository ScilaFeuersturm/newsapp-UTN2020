import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:5001/api",
});

export async function getNewsList() {
  let news = [];
  try {
    const response = await instance.get("/news");
    console.log(response);
    if (response.status === 200) {
      news = response.data;
      return { status: true, data: news };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}

export async function getNews(id) {
  try {
    const response = await instance.get(`/news/${id}`);
    if (response.status === 200) {
      return { status: true, data: response.data };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}
